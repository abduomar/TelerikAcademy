using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightPay.Data.Migrations
{
    public partial class DeleteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_SavedTransactions_SavedTransactionId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "SavedTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_SavedTransactionId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "SavedTransactionId",
                table: "Accounts");

            migrationBuilder.AddColumn<bool>(
                name: "IsSaved",
                table: "Accounts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSaved",
                table: "Accounts");

            migrationBuilder.AddColumn<string>(
                name: "TimeStamp",
                table: "Transactions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SavedTransactionId",
                table: "Accounts",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "SavedTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ammount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    TimeStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavedTransactions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_SavedTransactionId",
                table: "Accounts",
                column: "SavedTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_SavedTransactions_SavedTransactionId",
                table: "Accounts",
                column: "SavedTransactionId",
                principalTable: "SavedTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
