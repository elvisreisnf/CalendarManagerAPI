using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalendarManager.Infraestructure.Migrations
{
    public partial class AlterNameProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Event",
                newName: "EventName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Event",
                newName: "Name");
        }
    }
}
