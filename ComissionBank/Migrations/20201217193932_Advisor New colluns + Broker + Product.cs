using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class AdvisorNewcollunsBrokerProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrokerId",
                table: "Comission",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseId",
                table: "Comission",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Comission",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Comission",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Bank",
                table: "Advisor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BankAccount",
                table: "Advisor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAgency",
                table: "Advisor",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Advisor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Cfp",
                table: "Advisor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Advisor",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Employee",
                table: "Advisor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Initial",
                table: "Advisor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Matrix",
                table: "Advisor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Advisor",
                nullable: true);

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
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comission_BrokerId",
                table: "Comission",
                column: "BrokerId");

            migrationBuilder.CreateIndex(
                name: "IX_Comission_HouseId",
                table: "Comission",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Comission_ProductId",
                table: "Comission",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comission_Broker_BrokerId",
                table: "Comission",
                column: "BrokerId",
                principalTable: "Broker",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comission_House_HouseId",
                table: "Comission",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comission_Product_ProductId",
                table: "Comission",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comission_Broker_BrokerId",
                table: "Comission");

            migrationBuilder.DropForeignKey(
                name: "FK_Comission_House_HouseId",
                table: "Comission");

            migrationBuilder.DropForeignKey(
                name: "FK_Comission_Product_ProductId",
                table: "Comission");

            migrationBuilder.DropTable(
                name: "Broker");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Comission_BrokerId",
                table: "Comission");

            migrationBuilder.DropIndex(
                name: "IX_Comission_HouseId",
                table: "Comission");

            migrationBuilder.DropIndex(
                name: "IX_Comission_ProductId",
                table: "Comission");

            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "Comission");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Comission");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Comission");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Comission");

            migrationBuilder.DropColumn(
                name: "Bank",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "BankAgency",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "Cfp",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "Employee",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "Initial",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "Matrix",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Advisor");
        }
    }
}
