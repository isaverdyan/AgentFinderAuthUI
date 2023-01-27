using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentFinder.Identity.Migrations
{
    public partial class ChangeAgentUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Users_AgentId",
                table: "Agent");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "Agent",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Agent_AgentId",
                table: "Agent",
                newName: "IX_Agent_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Users_UserId",
                table: "Agent",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Users_UserId",
                table: "Agent");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Agent",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Agent_UserId",
                table: "Agent",
                newName: "IX_Agent_AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Users_AgentId",
                table: "Agent",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
