using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fa22Team16.Migrations
{
    /// <inheritdoc />
    public partial class Gabriel6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "StockTransactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockTransactions_AppUserId",
                table: "StockTransactions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_AspNetUsers_AppUserId",
                table: "StockTransactions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_AspNetUsers_AppUserId",
                table: "StockTransactions");

            migrationBuilder.DropIndex(
                name: "IX_StockTransactions_AppUserId",
                table: "StockTransactions");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "StockTransactions");
        }
    }
}
