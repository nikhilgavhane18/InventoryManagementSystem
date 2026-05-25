using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStockTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "StockType",
                table: "Stocks",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Stocks",
                newName: "StockQuantity");

            migrationBuilder.RenameColumn(
                name: "SId",
                table: "Stocks",
                newName: "StockId");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_PId",
                table: "Stocks",
                column: "PId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_PId",
                table: "Stocks",
                column: "PId",
                principalTable: "Products",
                principalColumn: "PId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_PId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_PId",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "StockQuantity",
                table: "Stocks",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Stocks",
                newName: "StockType");

            migrationBuilder.RenameColumn(
                name: "StockId",
                table: "Stocks",
                newName: "SId");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
