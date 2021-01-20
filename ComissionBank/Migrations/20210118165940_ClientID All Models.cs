using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class ClientIDAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Xp",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Protect",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Pan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Xp_ClientId",
                table: "Xp",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Protect_ClientId",
                table: "Protect",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Pan_ClientId",
                table: "Pan",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pan_Client_ClientId",
                table: "Pan",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Protect_Client_ClientId",
                table: "Protect",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Xp_Client_ClientId",
                table: "Xp",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pan_Client_ClientId",
                table: "Pan");

            migrationBuilder.DropForeignKey(
                name: "FK_Protect_Client_ClientId",
                table: "Protect");

            migrationBuilder.DropForeignKey(
                name: "FK_Xp_Client_ClientId",
                table: "Xp");

            migrationBuilder.DropIndex(
                name: "IX_Xp_ClientId",
                table: "Xp");

            migrationBuilder.DropIndex(
                name: "IX_Protect_ClientId",
                table: "Protect");

            migrationBuilder.DropIndex(
                name: "IX_Pan_ClientId",
                table: "Pan");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Xp");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Protect");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Pan");
        }
    }
}
