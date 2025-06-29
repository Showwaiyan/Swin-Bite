using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swin_Bite.API.Migrations
{
    /// <inheritdoc />
    public partial class phase51 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Users",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Vehivle",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryDriverId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "BankId", "AccountNumber", "Balance", "IsActive", "Pin" },
                values: new object[,]
                {
                    { 100005, "02468022", 500.00m, true, "4321" },
                    { 100006, "13579135", 750.00m, true, "9876" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Address", "UserType" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "Address", "UserType" },
                values: new object[] { null, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "UserType",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "UserType",
                value: 2);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "BankAccountId", "Email", "IsAuthenticated", "IsAvailable", "LicenseNumber", "Password", "UserType", "Username", "Vehivle" },
                values: new object[,]
                {
                    { 5, null, 100005, "johnwick@jw.com", false, false, null, "johnwikck123", 3, "John Wick", 0 },
                    { 6, null, 100006, "skywalker@starwar.com", false, false, null, "skywalker321", 3, "SkyWalker", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryDriverId",
                table: "Orders",
                column: "DeliveryDriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_DeliveryDriverId",
                table: "Orders",
                column: "DeliveryDriverId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_DeliveryDriverId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryDriverId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "BankId",
                keyValue: 100005);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "BankId",
                keyValue: 100006);

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Vehivle",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeliveryDriverId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "BankAccountId", "Email", "IsAuthenticated", "Password", "UserType", "Username" },
                values: new object[,]
                {
                    { 1, 100001, "johnsnow@got.com", false, "johnsnow123", 0, "John Snow" },
                    { 2, 100002, "frodo@lotr.com", false, "frodo321", 0, "Frodo" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "BankAccountId", "Email", "IsAuthenticated", "Name", "OperatingHours", "Password", "Rating", "UserType", "Username" },
                values: new object[,]
                {
                    { 3, null, 100003, "walterwhite@breakingbad.com", false, "ChemistryChad", null, "lethimcook", 0f, 1, "Walter White" },
                    { 4, null, 100004, "dean@supernatural.com", false, "ApplePi", null, "iambatman", 0f, 1, "Dean Winchester" }
                });
        }
    }
}
