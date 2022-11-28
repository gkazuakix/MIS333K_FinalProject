using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fa22Team16.Migrations
{
    /// <inheritdoc />
    public partial class FixModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_BankAccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BankAccountID",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "BankAccountID",
                table: "Transactions",
                newName: "Type");

            migrationBuilder.AlterColumn<int>(
                name: "Approved",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccountBankAccountID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BankAccountID",
                table: "StockTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StockTransactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "StockTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountBankAccountID",
                table: "Transactions",
                column: "AccountBankAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_BankAccountID",
                table: "StockTransactions",
                column: "BankAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_BankAccounts_BankAccountID",
                table: "StockTransactions",
                column: "BankAccountID",
                principalTable: "BankAccounts",
                principalColumn: "BankAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_AccountBankAccountID",
                table: "Transactions",
                column: "AccountBankAccountID",
                principalTable: "BankAccounts",
                principalColumn: "BankAccountID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_BankAccounts_BankAccountID",
                table: "StockTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_AccountBankAccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AccountBankAccountID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_StockTransactions_BankAccountID",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "AccountBankAccountID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BankAccountID",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "StockTransactions");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Transactions",
                newName: "BankAccountID");

            migrationBuilder.AlterColumn<bool>(
                name: "Approved",
                table: "Transactions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BankAccountID",
                table: "Transactions",
                column: "BankAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_BankAccountID",
                table: "Transactions",
                column: "BankAccountID",
                principalTable: "BankAccounts",
                principalColumn: "BankAccountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
