using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentFinder.Identity.Migrations
{
    public partial class AddingMenuOptionsChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MenuType",
                table: "MenuOptions",
                newName: "Target");

            migrationBuilder.AddColumn<string>(
                name: "AltText",
                table: "MenuOptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageCode",
                table: "MenuOptions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "MenuOptions",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltText",
                table: "MenuOptions");

            migrationBuilder.DropColumn(
                name: "LanguageCode",
                table: "MenuOptions");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "MenuOptions");

            migrationBuilder.RenameColumn(
                name: "Target",
                table: "MenuOptions",
                newName: "MenuType");
        }
    }
}
