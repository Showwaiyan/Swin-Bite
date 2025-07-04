﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Swin_Bite.API.Migrations
{
    /// <inheritdoc />
    public partial class phase4finaldistinction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    BankId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountNumber = table.Column<string>(type: "text", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    Pin = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.BankId);
                    table.UniqueConstraint("AK_BankAccounts_AccountNumber", x => x.AccountNumber);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    IsAuthenticated = table.Column<bool>(type: "boolean", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    BankAccountId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    OperatingHours = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "BankId");
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    PrepTime = table.Column<int>(type: "integer", nullable: false),
                    ServingSize = table.Column<int>(type: "integer", nullable: true),
                    SpiceLevel = table.Column<int>(type: "integer", nullable: true),
                    Calories = table.Column<int>(type: "integer", nullable: true),
                    Ingredients = table.Column<List<string>>(type: "text[]", nullable: true),
                    Volume = table.Column<int>(type: "integer", nullable: true),
                    Temperature = table.Column<int>(type: "integer", nullable: true),
                    IsCarbonated = table.Column<bool>(type: "boolean", nullable: true),
                    HasAlcohol = table.Column<bool>(type: "boolean", nullable: true),
                    PackageSize = table.Column<int>(type: "integer", nullable: true),
                    IsHealthy = table.Column<bool>(type: "boolean", nullable: true),
                    Allergens = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Foods_Users_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    RestaurantId = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PickUpTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    ShoppingCartId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.ShoppingCartId);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Users_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PriceAtTime = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "integer", nullable: false),
                    FoodId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "ShoppingCartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "BankId", "AccountNumber", "Balance", "IsActive", "Pin" },
                values: new object[,]
                {
                    { 100001, "12345678", 500.00m, true, "1234" },
                    { 100002, "87654321", 300.00m, true, "5678" },
                    { 100003, "24681012", 300.00m, true, "4321" },
                    { 100004, "01357911", 300.00m, true, "8765" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Foods_RestaurantId",
                table: "Foods",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FoodId",
                table: "OrderItems",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_FoodId",
                table: "ShoppingCartItems",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                table: "ShoppingCartItems",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_CustomerId",
                table: "ShoppingCarts",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BankAccountId",
                table: "Users",
                column: "BankAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BankAccounts");
        }
    }
}
