using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentFinder.Identity.Migrations
{
    public partial class AgentLocationChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_AgentsInterestsLocations_AgentInterestsLocationId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AgentInterestsLocationId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AgentInterestsLocationId",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "AgentsInterestsLocations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "AgentsInterestsLocations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AgentsInterestsLocations_LocationId",
                table: "AgentsInterestsLocations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentsInterestsLocations_userId",
                table: "AgentsInterestsLocations",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentsInterestsLocations_Locations_LocationId",
                table: "AgentsInterestsLocations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentsInterestsLocations_Users_userId",
                table: "AgentsInterestsLocations",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentsInterestsLocations_Locations_LocationId",
                table: "AgentsInterestsLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_AgentsInterestsLocations_Users_userId",
                table: "AgentsInterestsLocations");

            migrationBuilder.DropIndex(
                name: "IX_AgentsInterestsLocations_LocationId",
                table: "AgentsInterestsLocations");

            migrationBuilder.DropIndex(
                name: "IX_AgentsInterestsLocations_userId",
                table: "AgentsInterestsLocations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "AgentsInterestsLocations");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "AgentsInterestsLocations");

            migrationBuilder.AddColumn<int>(
                name: "AgentInterestsLocationId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AgentInterestsLocationId",
                table: "Locations",
                column: "AgentInterestsLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_AgentsInterestsLocations_AgentInterestsLocationId",
                table: "Locations",
                column: "AgentInterestsLocationId",
                principalTable: "AgentsInterestsLocations",
                principalColumn: "Id");
        }
    }
}
