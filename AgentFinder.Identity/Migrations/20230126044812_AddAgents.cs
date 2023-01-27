using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentFinder.Identity.Migrations
{
    public partial class AddAgents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Locations_LocationId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Users_UserId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_AgentCustomers_Agent_AgentId",
                table: "AgentCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerNotifications_Agent_AgentId",
                table: "CustomerNotifications");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agent",
                table: "Agent");

            migrationBuilder.RenameTable(
                name: "Agent",
                newName: "Agents");

            migrationBuilder.RenameIndex(
                name: "IX_Agent_UserId",
                table: "Agents",
                newName: "IX_Agents_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Agent_LocationId",
                table: "Agents",
                newName: "IX_Agents_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AgentCustomers_Agents_AgentId",
                table: "AgentCustomers",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Locations_LocationId",
                table: "Agents",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Users_UserId",
                table: "Agents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerNotifications_Agents_AgentId",
                table: "CustomerNotifications",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentCustomers_Agents_AgentId",
                table: "AgentCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Locations_LocationId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Users_UserId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerNotifications_Agents_AgentId",
                table: "CustomerNotifications");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.RenameTable(
                name: "Agents",
                newName: "Agent");

            migrationBuilder.RenameIndex(
                name: "IX_Agents_UserId",
                table: "Agent",
                newName: "IX_Agent_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Agents_LocationId",
                table: "Agent",
                newName: "IX_Agent_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agent",
                table: "Agent",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Locations_LocationId",
                table: "Agent",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Users_UserId",
                table: "Agent",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentCustomers_Agent_AgentId",
                table: "AgentCustomers",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerNotifications_Agent_AgentId",
                table: "CustomerNotifications",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id");
        }
    }
}
