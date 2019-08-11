using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartChurch.Migrations
{
    public partial class ModifyAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Attendances");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Attendances",
                nullable: false,
                defaultValue: false);
        }
    }
}
