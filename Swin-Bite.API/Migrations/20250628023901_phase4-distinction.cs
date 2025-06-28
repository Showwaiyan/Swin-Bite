using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swin_Bite.API.Migrations
{
    /// <inheritdoc />
    public partial class phase4distinction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Calories", "Category", "Ingredients", "IsAvailable", "Name", "PrepTime", "Price", "RestaurantId", "ServingSize", "SpiceLevel" },
                values: new object[] { 1, 0, 0, new List<string>(), true, "Spicy Noodles", 0, 10.00m, 3, 0, 0 });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Category", "HasAlcohol", "IsAvailable", "IsCarbonated", "Name", "PrepTime", "Price", "RestaurantId", "Temperature", "Volume" },
                values: new object[] { 2, 1, false, true, false, "Iced Tea", 0, 3.00m, 3, 0, 0 });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Calories", "Category", "Ingredients", "IsAvailable", "Name", "PrepTime", "Price", "RestaurantId", "ServingSize", "SpiceLevel" },
                values: new object[] { 3, 0, 0, new List<string>(), true, "Grilled Chicken", 0, 12.00m, 4, 0, 0 });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Category", "HasAlcohol", "IsAvailable", "IsCarbonated", "Name", "PrepTime", "Price", "RestaurantId", "Temperature", "Volume" },
                values: new object[] { 4, 1, false, true, false, "Lemonade", 0, 2.50m, 4, 0, 0 });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "ShoppingCartId", "CustomerId", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 1, 0m },
                    { 2, 2, 0m }
                });
        }
    }
}
