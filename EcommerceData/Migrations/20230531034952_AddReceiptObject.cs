using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceData.Migrations
{
    public partial class AddReceiptObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptID",
                table: "Carts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Carts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Accounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phonenumber",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(nullable: false),
                    TotalSum = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receipts_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ReceiptID",
                table: "Carts",
                column: "ReceiptID");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_AccountID",
                table: "Receipts",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Receipts_ReceiptID",
                table: "Carts",
                column: "ReceiptID",
                principalTable: "Receipts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Receipts_ReceiptID",
                table: "Carts");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ReceiptID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ReceiptID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "Phonenumber",
                table: "Accounts");
        }
    }
}
