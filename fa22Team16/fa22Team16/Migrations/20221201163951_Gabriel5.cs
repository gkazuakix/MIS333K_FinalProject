using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fa22Team16.Migrations
{
    /// <inheritdoc />
    public partial class Gabriel5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CurrentValue",
                table: "StockTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Bonus",
                table: "StockPortfolios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "StockPortfolioCashBalance",
                table: "StockPortfolios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentValue",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "Bonus",
                table: "StockPortfolios");

            migrationBuilder.DropColumn(
                name: "StockPortfolioCashBalance",
                table: "StockPortfolios");
        }
    }
}
