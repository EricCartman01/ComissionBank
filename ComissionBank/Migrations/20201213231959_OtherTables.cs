using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class OtherTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Broker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exchange",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    AdvisorId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Currency = table.Column<int>(nullable: false),
                    GrossValue = table.Column<double>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Cotation = table.Column<double>(nullable: false),
                    ComissionType = table.Column<int>(nullable: false),
                    Spread = table.Column<double>(nullable: false),
                    Comission = table.Column<double>(nullable: false),
                    NetValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exchange_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    BrokerId = table.Column<int>(nullable: true),
                    AdvisorId = table.Column<int>(nullable: false),
                    ClientCode = table.Column<string>(nullable: true),
                    Yield = table.Column<int>(nullable: false),
                    ClientId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Value = table.Column<double>(nullable: false),
                    LiquidValue = table.Column<double>(nullable: false),
                    PercentualAdvisor = table.Column<double>(nullable: false),
                    AdvisorValue = table.Column<double>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comission_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comission_Broker_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Broker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comission_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comission_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comission_AdvisorId",
                table: "Comission",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comission_BrokerId",
                table: "Comission",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comission_ClientId",
                table: "Comission",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Comission_ProductId",
                table: "Comission",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchange_AdvisorId",
                table: "Exchange",
                column: "AdvisorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comission");

            migrationBuilder.DropTable(
                name: "Exchange");

            migrationBuilder.DropTable(
                name: "Broker");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
