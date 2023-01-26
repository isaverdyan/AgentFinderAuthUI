using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentFinder.Identity.Migrations
{
    public partial class AddAgentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Agent");

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Agent",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "Agent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyPhone",
                table: "Agent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyPhone2",
                table: "Agent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "CompanyRating",
                table: "Agent",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agent_AgentId",
                table: "Agent",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Users_AgentId",
                table: "Agent",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Users_AgentId",
                table: "Agent");

            migrationBuilder.DropIndex(
                name: "IX_Agent_AgentId",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "CompanyPhone",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "CompanyPhone2",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "CompanyRating",
                table: "Agent");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Agent",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
