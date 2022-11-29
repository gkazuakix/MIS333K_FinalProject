using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fa22Team16.Migrations
{
    /// <inheritdoc />
    public partial class AddPortfoliotoTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockPortfolioID",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StockPortfolioID",
                table: "Transactions",
                column: "StockPortfolioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_StockPortfolios_StockPortfolioID",
                table: "Transactions",
                column: "StockPortfolioID",
                principalTable: "StockPortfolios",
                principalColumn: "StockPortfolioID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_StockPortfolios_StockPortfolioID",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_StockPortfolioID",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StockPortfolioID",
                table: "Transactions");
        }
    }
}
