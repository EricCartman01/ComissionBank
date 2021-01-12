using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class Pan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NetValue",
                table: "Exchange",
                newName: "OperatorValue");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Exchange",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Month",
                table: "Exchange",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "BankValue",
                table: "Exchange",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NetAdvisorValue",
                table: "Exchange",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Pan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Record = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientCode = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    AdvisorId = table.Column<int>(nullable: false),
                    AdvisorInitials = table.Column<string>(nullable: true),
                    PanValue = table.Column<double>(nullable: false),
                    PanLiquidValue = table.Column<double>(nullable: false),
                    NetAdvisorValue = table.Column<double>(nullable: false),
                    BankValue = table.Column<double>(nullable: false),
                    AdvisorValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pan_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pan_AdvisorId",
                table: "Pan",
                column: "AdvisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pan");

            migrationBuilder.DropColumn(
                name: "BankValue",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "NetAdvisorValue",
                table: "Exchange");

            migrationBuilder.RenameColumn(
                name: "OperatorValue",
                table: "Exchange",
                newName: "NetValue");

            migrationBuilder.AlterColumn<string>(
                name: "Year",
                table: "Exchange",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Month",
                table: "Exchange",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
