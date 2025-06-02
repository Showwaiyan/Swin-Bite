using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Swin_Bite.API.Migrations
{
    /// <inheritdoc />
    public partial class UserNVReferenceAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "BankAccountBankId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BankAccountBankId",
                table: "Users",
                column: "BankAccountBankId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BankAccounts_BankAccountBankId",
                table: "Users",
                column: "BankAccountBankId",
                principalTable: "BankAccounts",
                principalColumn: "BankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_BankAccounts_BankAccountBankId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BankAccountBankId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BankAccountBankId",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
