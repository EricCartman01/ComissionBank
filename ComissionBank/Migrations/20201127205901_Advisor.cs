using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class Advisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teste");

            migrationBuilder.CreateTable(
                name: "Advisor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Initials = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    NetCertification = table.Column<double>(nullable: false),
                    Net = table.Column<double>(nullable: false),
                    NetBirthday = table.Column<double>(nullable: false),
                    NetTotal = table.Column<double>(nullable: false),
                    XPC = table.Column<double>(nullable: false),
                    CMBC = table.Column<double>(nullable: false),
                    PROTC = table.Column<double>(nullable: false),
                    ITAZ = table.Column<double>(nullable: false),
                    JURC = table.Column<double>(nullable: false),
                    PAN = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advisor");

            migrationBuilder.CreateTable(
                name: "Teste",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Idade = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teste", x => x.Id);
                });
        }
    }
}
