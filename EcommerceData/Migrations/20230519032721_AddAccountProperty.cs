using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceData.Migrations
{
    public partial class AddAccountProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CartInfo",
                table: "Accounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartInfo",
                table: "Accounts");
        }
    }
}
