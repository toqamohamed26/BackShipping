using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shipping.Migrations
{
    /// <inheritdoc />
    public partial class lastVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_orderId_Order",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_orderId_Order",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "orderId_Order",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Id_Order",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id_Order",
                table: "Products",
                column: "Id_Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_Id_Order",
                table: "Products",
                column: "Id_Order",
                principalTable: "Orders",
                principalColumn: "Id_Order");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_Id_Order",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Id_Order",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Id_Order",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "orderId_Order",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_orderId_Order",
                table: "Products",
                column: "orderId_Order");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_orderId_Order",
                table: "Products",
                column: "orderId_Order",
                principalTable: "Orders",
                principalColumn: "Id_Order");
        }
    }
}
