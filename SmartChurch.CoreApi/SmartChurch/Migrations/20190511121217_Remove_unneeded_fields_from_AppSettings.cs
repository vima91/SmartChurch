using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartChurch.Migrations
{
    public partial class Remove_unneeded_fields_from_AppSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankBalanceReminder",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "ChurchBalanceReminder",
                table: "AppSettings");

            migrationBuilder.DropColumn(
                name: "StartOfSchoolYear",
                table: "AppSettings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BankBalanceReminder",
                table: "AppSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChurchBalanceReminder",
                table: "AppSettings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartOfSchoolYear",
                table: "AppSettings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
