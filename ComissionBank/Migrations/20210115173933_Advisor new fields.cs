using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class Advisornewfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Advisor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Record",
                table: "Advisor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "XpCode",
                table: "Advisor",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Xp",
                columns: table => new
                {
                    Register = table.Column<DateTime>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientCode = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    AdvisorInitials = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    Market = table.Column<string>(nullable: true),
                    GrossIncomeValue = table.Column<double>(nullable: false),
                    GrossLiquidValue = table.Column<double>(nullable: false),
                    NetProductValue = table.Column<double>(nullable: false),
                    TransferValue = table.Column<double>(nullable: false),
                    LiquidValue = table.Column<double>(nullable: false),
                    NetAdvisorValue = table.Column<double>(nullable: false),
                    AdvisorValue = table.Column<double>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xp", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Xp");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "Record",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "XpCode",
                table: "Advisor");
        }
    }
}
