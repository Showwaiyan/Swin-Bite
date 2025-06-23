using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swin_Bite.API.Migrations
{
    /// <inheritdoc />
    public partial class Phase44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalQuantity",
                table: "Foods");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "ShoppingCarts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 1,
                column: "TotalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "ShoppingCarts",
                keyColumn: "ShoppingCartId",
                keyValue: 2,
                column: "TotalPrice",
                value: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "TotalQuantity",
                table: "Foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1,
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2,
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3,
                columns: new string[0],
                values: new object[0]);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 4,
                columns: new string[0],
                values: new object[0]);
        }
    }
}
