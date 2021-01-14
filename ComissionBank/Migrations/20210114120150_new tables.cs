using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class newtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Record",
                table: "Client",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Protect",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Record = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    HouseId = table.Column<int>(nullable: false),
                    AdvisorId = table.Column<int>(nullable: false),
                    AdvisorInitials = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    LiquidValue = table.Column<double>(nullable: false),
                    NetValue = table.Column<double>(nullable: false),
                    AdvisorValue = table.Column<double>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Protect_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Protect_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Protect_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Protect_AdvisorId",
                table: "Protect",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Protect_HouseId",
                table: "Protect",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Protect_ProductId",
                table: "Protect",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Protect");

            migrationBuilder.DropColumn(
                name: "Record",
                table: "Client");
        }
    }
}
