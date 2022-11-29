using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fa22Team16.Migrations
{
    /// <inheritdoc />
    public partial class AddFeetoTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_BankAccounts_BankAccountID",
                table: "StockTransactions");

            migrationBuilder.DropIndex(
                name: "IX_StockTransactions_BankAccountID",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "BankAccountID",
                table: "StockTransactions");

            migrationBuilder.AddColumn<int>(
                name: "TransactionNum",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionNum",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "BankAccountID",
                table: "StockTransactions",
                type: "int",
                nullable: true);

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
        }
    }
}
