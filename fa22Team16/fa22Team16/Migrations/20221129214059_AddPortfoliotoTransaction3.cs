using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fa22Team16.Migrations
{
    /// <inheritdoc />
    public partial class AddPortfoliotoTransaction3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_AccountBankAccountID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_StockPortfolios_StockPortfolioID",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "StockPortfolioID",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AccountBankAccountID",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_AccountBankAccountID",
                table: "Transactions",
                column: "AccountBankAccountID",
                principalTable: "BankAccounts",
                principalColumn: "BankAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_StockPortfolios_StockPortfolioID",
                table: "Transactions",
                column: "StockPortfolioID",
                principalTable: "StockPortfolios",
                principalColumn: "StockPortfolioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_BankAccounts_AccountBankAccountID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_StockPortfolios_StockPortfolioID",
                table: "Transactions");

            migrationBuilder.AlterColumn<int>(
                name: "StockPortfolioID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountBankAccountID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_BankAccounts_AccountBankAccountID",
                table: "Transactions",
                column: "AccountBankAccountID",
                principalTable: "BankAccounts",
                principalColumn: "BankAccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_StockPortfolios_StockPortfolioID",
                table: "Transactions",
                column: "StockPortfolioID",
                principalTable: "StockPortfolios",
                principalColumn: "StockPortfolioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
