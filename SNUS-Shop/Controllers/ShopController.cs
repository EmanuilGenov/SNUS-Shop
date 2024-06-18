using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SnusShop.Data;
using SnusShop.Data.Data;
using SnusShop.Data.Models;
using SnusShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnusShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShopController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous] // Allow anonymous access to shop page
        public async Task<IActionResult> All()
        {
            var products = await _context.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price
                }).ToListAsync(); // Get all products
            return View(products);
        }

        // GET: /Shop/Details/{id}
        [AllowAnonymous] // Allow anonymous access to product details
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            var client = await GetCurrentUserAsync();
            if (client == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if client not found
            }

            var order = await _context.Orders
                .Include(o => o.OrderProducts)
                .Where(o => o.ClientId == client.Id && !o.IsCompleted)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                order = new Order
                {
                    Id = Guid.NewGuid(),
                    ClientId = client.Id,
                    OrderProducts = new List<OrderProduct>()
                };
                _context.Orders.Add(order);
            }

            var orderProduct = order.OrderProducts.FirstOrDefault(op => op.ProductId == productId);
            if (orderProduct == null)
            {
                orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = productId,
                    Quantity = quantity
                };
                _context.OrdersProducts.Add(orderProduct);
            }
            else
            {
                orderProduct.Quantity += quantity;
            }

            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var clientId = _userManager.GetUserId(User);
            var order = await _context.Orders
                                      .Include(o => o.OrderProducts)
                                      .FirstOrDefaultAsync(o => o.ClientId == clientId && !o.IsCompleted);

            if (order == null)
            {
                return NotFound();
            }

            var orderProduct = order.OrderProducts.FirstOrDefault(op => op.ProductId == productId);

            if (orderProduct != null)
            {
                if (orderProduct.Quantity > 1)
                {
                    orderProduct.Quantity -= 1;
                }
                else
                {
                    order.OrderProducts.Remove(orderProduct);
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Cart));
        }

        [HttpPost]
        public async Task<IActionResult> FinalizeOrder()
        {
            var clientId = _userManager.GetUserId(User);
            var order = await _context.Orders
                                      .Include(o => o.OrderProducts)
                                      .FirstOrDefaultAsync(o => o.ClientId == clientId && !o.IsCompleted);

            if (order != null)
            {
                order.IsCompleted = true;
                await _context.SaveChangesAsync();
            }

            TempData["OrderStatus"] = "Order sent";
            return RedirectToAction(nameof(OrderConfirmation));
        }

        public IActionResult OrderConfirmation()
        {
            return View();
        }

        // GET: /Shop/Cart
        public async Task<IActionResult> Cart()
        {
            var client = await GetCurrentUserAsync();
            if (client == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if client not found
            }

            var order = await _context.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
                .Where(o => o.ClientId == client.Id && !o.IsCompleted)
                .FirstOrDefaultAsync();

            if (order == null!)
            {
                return View(new List<OrderProductViewModel>());
            }

            var orderProductsViewModel = order.OrderProducts
                .Select(op => new OrderProductViewModel
                {
                    ProductId = op.ProductId,
                    ProductName = op.Product.Name,
                    Quantity = op.Quantity,
                    Price = op.Product.Price
                })
                .ToList();

            return View(orderProductsViewModel);
        }

        // Helper method to get current logged-in client
        private async Task<IdentityUser?> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(User);
        }
    }
}
