using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class Initial : Migration
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
                    Record = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    ClientCode = table.Column<string>(nullable: true),
                    AdvisorInitials = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Abbreviaton = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matrix",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Register = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matrix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Market = table.Column<int>(nullable: false),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

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
                    ClientId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Xp_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advisor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Record = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Telephone = table.Column<string>(nullable: true),
                    XpCode = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    BankAgency = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true),
                    Initial = table.Column<DateTime>(nullable: false),
                    Employee = table.Column<bool>(nullable: false),
                    MatrixName = table.Column<string>(nullable: true),
                    MatrixId = table.Column<int>(nullable: false),
                    Cfp = table.Column<string>(nullable: true),
                    NetCertification = table.Column<double>(nullable: false),
                    Net = table.Column<double>(nullable: false),
                    NetBirthday = table.Column<double>(nullable: false),
                    NetTotal = table.Column<double>(nullable: false),
                    XPC = table.Column<double>(nullable: false),
                    CMBC = table.Column<double>(nullable: false),
                    PROTC = table.Column<double>(nullable: false),
                    ITAZ = table.Column<double>(nullable: false),
                    JURC = table.Column<double>(nullable: false),
                    PAN = table.Column<double>(nullable: false),
                    XPTable = table.Column<double>(nullable: false),
                    IsHeadQuarter = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advisor_Matrix_MatrixId",
                        column: x => x.MatrixId,
                        principalTable: "Matrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Register = table.Column<DateTime>(nullable: false),
                    BrokerId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: true),
                    HouseId = table.Column<int>(nullable: false),
                    AdvisorId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ClientCode = table.Column<string>(nullable: true),
                    Order = table.Column<string>(nullable: true),
                    Yield = table.Column<string>(nullable: true),
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
                        name: "FK_Comission_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comission_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exchange",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Record = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AdvisorInitials = table.Column<string>(nullable: true),
                    AdvisorId = table.Column<int>(nullable: false),
                    HouseName = table.Column<string>(nullable: true),
                    HouseId = table.Column<int>(nullable: false),
                    Order = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    GrossValue = table.Column<double>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Cotation = table.Column<double>(nullable: false),
                    ComissionType = table.Column<string>(nullable: true),
                    Spread = table.Column<double>(nullable: false),
                    Comission = table.Column<double>(nullable: false),
                    LiquidValue = table.Column<double>(nullable: false),
                    NetAdvisorValue = table.Column<double>(nullable: false),
                    BankValue = table.Column<double>(nullable: false),
                    OperatorValue = table.Column<double>(nullable: false),
                    AdvisorValue = table.Column<double>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exchange_Advisor_AdvisorId",
                        column: x => x.AdvisorId,
                        principalTable: "Advisor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exchange_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exchange_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    ClientId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Pan_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Protect",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Record = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    ClientName = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    HouseId = table.Column<int>(nullable: false),
                    AdvisorId = table.Column<int>(nullable: false),
                    AdvisorInitials = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    ProtectValue = table.Column<double>(nullable: false),
                    ProtectLiquidValue = table.Column<double>(nullable: false),
                    NetAdvisorValue = table.Column<double>(nullable: false),
                    BankValue = table.Column<double>(nullable: false),
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
                        name: "FK_Protect_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
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
                name: "IX_Advisor_MatrixId",
                table: "Advisor",
                column: "MatrixId");

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
                name: "IX_Comission_HouseId",
                table: "Comission",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comission_ProductId",
                table: "Comission",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchange_AdvisorId",
                table: "Exchange",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchange_ClientId",
                table: "Exchange",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Exchange_HouseId",
                table: "Exchange",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Pan_AdvisorId",
                table: "Pan",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pan_ClientId",
                table: "Pan",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Protect_AdvisorId",
                table: "Protect",
                column: "AdvisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Protect_ClientId",
                table: "Protect",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Protect_HouseId",
                table: "Protect",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Protect_ProductId",
                table: "Protect",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Xp_ClientId",
                table: "Xp",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comission");

            migrationBuilder.DropTable(
                name: "Exchange");

            migrationBuilder.DropTable(
                name: "Pan");

            migrationBuilder.DropTable(
                name: "Protect");

            migrationBuilder.DropTable(
                name: "Xp");

            migrationBuilder.DropTable(
                name: "Broker");

            migrationBuilder.DropTable(
                name: "Advisor");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Matrix");
        }
    }
}
