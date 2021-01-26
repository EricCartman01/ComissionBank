using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class RemoveMatrixFKfromadvisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advisor_Matrix_MatrixId",
                table: "Advisor");

            migrationBuilder.DropIndex(
                name: "IX_Advisor_MatrixId",
                table: "Advisor");

            migrationBuilder.DropColumn(
                name: "MatrixId",
                table: "Advisor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatrixId",
                table: "Advisor",
                nullable: false,
                defaultValue: 0);

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
        }
    }
}
