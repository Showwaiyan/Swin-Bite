using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swin_Bite.API.Migrations
{
    /// <inheritdoc />
    public partial class ShoppingCartItemManyToOneWithFood : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_FoodId",
                table: "ShoppingCartItems");

            migrationBuilder.AddColumn<int>(
                name: "PrepTime",
                table: "Foods",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1,
                column: "PrepTime",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2,
                column: "PrepTime",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3,
                column: "PrepTime",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 4,
                column: "PrepTime",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_FoodId",
                table: "ShoppingCartItems",
                column: "FoodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_FoodId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "PrepTime",
                table: "Foods");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_FoodId",
                table: "ShoppingCartItems",
                column: "FoodId",
                unique: true);
        }
    }
}
