using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SnusShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class BetterSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Description for product 1", "https://dip-store.com/_next/image?url=http%3A%2F%2Fstatic.dripeurope.com%2Fproducts%2FPAZ%2Fpaz-x_freeze.png&w=1920&q=75", "Product 1", 19.99m },
                    { 2, "Description for product 2", "https://dip-store.com/_next/image?url=https%3A%2F%2Fstatic.dripeurope.com%2FDIP%2520STORE%2FProducts%2FPAZ%2Fpazz-daytona.png&w=1080&q=75", "Product 2", 24.99m },
                    { 3, "Description for product 3", "https://dip-store.com/_next/image?url=https%3A%2F%2Fstatic.dripeurope.com%2FDIP%2520STORE%2FProducts%2FV%26YOU%2F%26BOOST%2B%2Fboost%2B-cool-berry-new.png&w=1080&q=75", "Product 3", 29.99m },
                    { 4, "Description for product 4", "https://dip-store.com/_next/image?url=http%3A%2F%2Fstatic.dripeurope.com%2Fproducts%2FACE%2Fcool%2520mint%2Face-cool_mint-front-opened.png&w=1080&q=75", "Product 4", 34.99m },
                    { 5, "Description for product 5", "https://dip-store.com/_next/image?url=http%3A%2F%2Fstatic.dripeurope.com%2Fproducts%2FACE%2520X%2Face_x-cool_mint-side.png&w=1080&q=75", "Product 5", 39.99m },
                    { 6, "Description for product 6", "https://dip-store.com/_next/image?url=https%3A%2F%2Fstatic.dripeurope.com%2FDIP%2520STORE%2FProducts%2FV%26YOU%2F%26BOOST%2Fboost-blueberry-old.png&w=1080&q=75", "Product 6", 44.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
