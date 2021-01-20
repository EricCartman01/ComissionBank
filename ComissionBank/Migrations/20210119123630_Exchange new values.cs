using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class Exchangenewvalues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "House",
                table: "Exchange",
                newName: "HouseName");

            migrationBuilder.RenameColumn(
                name: "Matrix",
                table: "Advisor",
                newName: "MatrixName");

            migrationBuilder.AddColumn<int>(
                name: "HouseId",
                table: "Exchange",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsHeadQuarter",
                table: "Advisor",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MatrixId",
                table: "Advisor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "XPTable",
                table: "Advisor",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Exchange_HouseId",
                table: "Exchange",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisor_MatrixId",
                table: "Advisor",
                column: "MatrixId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advisor_Matrix_MatrixId",
                table: "Advisor",
                column: "MatrixId",
                principalTable: "Matrix",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchange_House_HouseId",
                table: "Exchange",
                column: "HouseId",
                principalTable: "House",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advisor_Matrix_MatrixId",
                table: "Advisor");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchange_House_HouseId",
                table: "Exchange");

            migrationBuilder.DropIndex(
                name: "IX_Exchange_HouseId",
                table: "Exchange");

            migrationBuilder.DropIndex(
                name: "IX_Advisor_MatrixId",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "IsHeadQuarter",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "MatrixId",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "XPTable",
                table: "Advisor");

            migrationBuilder.RenameColumn(
                name: "HouseName",
                table: "Exchange",
                newName: "House");

            migrationBuilder.RenameColumn(
                name: "MatrixName",
                table: "Advisor",
                newName: "Matrix");
        }
    }
}
