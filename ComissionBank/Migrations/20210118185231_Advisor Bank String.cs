using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class AdvisorBankString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Bank",
                table: "Advisor",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Bank",
                table: "Advisor",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
