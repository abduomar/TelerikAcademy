using Microsoft.EntityFrameworkCore.Migrations;

namespace LightPay.Data.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSaved",
                table: "Accounts");

            migrationBuilder.AddColumn<bool>(
                name: "IsSaved",
                table: "Transactions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSaved",
                table: "Transactions");

            migrationBuilder.AddColumn<bool>(
                name: "IsSaved",
                table: "Accounts",
                nullable: false,
                defaultValue: false);
        }
    }
}
