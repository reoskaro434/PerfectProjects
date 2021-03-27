using Microsoft.EntityFrameworkCore.Migrations;

namespace PerfectProjects.DataAccess.Migrations
{
    public partial class AddisVisibleToShortDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "ShortDescriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "ShortDescriptions");
        }
    }
}
