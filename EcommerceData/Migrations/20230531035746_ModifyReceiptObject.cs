using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceData.Migrations
{
    public partial class ModifyReceiptObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Receipts_ReceiptID",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ReceiptID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ReceiptID",
                table: "Carts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptID",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ReceiptID",
                table: "Carts",
                column: "ReceiptID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Receipts_ReceiptID",
                table: "Carts",
                column: "ReceiptID",
                principalTable: "Receipts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
