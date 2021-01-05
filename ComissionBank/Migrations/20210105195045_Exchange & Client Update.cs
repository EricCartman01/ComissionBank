using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComissionBank.Migrations
{
    public partial class ExchangeClientUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchange_Advisor_AdvisorId",
                table: "Exchange");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Exchange",
                newName: "Year");

            migrationBuilder.AlterColumn<string>(
                name: "Order",
                table: "Exchange",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Exchange",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "ComissionType",
                table: "Exchange",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AdvisorId",
                table: "Exchange",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdvisorInitials",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AdvisorValue",
                table: "Exchange",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Exchange",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "House",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LiquidValue",
                table: "Exchange",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Exchange",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Record",
                table: "Exchange",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Exchange_ClientId",
                table: "Exchange",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exchange_Advisor_AdvisorId",
                table: "Exchange",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exchange_Client_ClientId",
                table: "Exchange",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exchange_Advisor_AdvisorId",
                table: "Exchange");

            migrationBuilder.DropForeignKey(
                name: "FK_Exchange_Client_ClientId",
                table: "Exchange");

            migrationBuilder.DropIndex(
                name: "IX_Exchange_ClientId",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "AdvisorInitials",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "AdvisorValue",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "House",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "LiquidValue",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Exchange");

            migrationBuilder.DropColumn(
                name: "Record",
                table: "Exchange");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Exchange",
                newName: "FirstName");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Exchange",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Currency",
                table: "Exchange",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ComissionType",
                table: "Exchange",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdvisorId",
                table: "Exchange",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Exchange_Advisor_AdvisorId",
                table: "Exchange",
                column: "AdvisorId",
                principalTable: "Advisor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
