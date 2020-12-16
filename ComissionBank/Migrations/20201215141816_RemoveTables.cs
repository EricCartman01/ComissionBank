using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class RemoveTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comission_Broker_BrokerId",
                table: "Comission");

            migrationBuilder.DropForeignKey(
                name: "FK_Comission_Product_ProductId",
                table: "Comission");

            migrationBuilder.DropTable(
                name: "Broker");

            migrationBuilder.DropIndex(
                name: "IX_Comission_BrokerId",
                table: "Comission");

            migrationBuilder.DropIndex(
                name: "IX_Comission_ProductId",
                table: "Comission");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BrokerId",
                table: "Comission");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Comission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Product",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "BrokerId",
                table: "Comission",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Comission",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Broker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Details = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broker", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comission_BrokerId",
                table: "Comission",
                column: "BrokerId");

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
                name: "FK_Comission_Product_ProductId",
                table: "Comission",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
