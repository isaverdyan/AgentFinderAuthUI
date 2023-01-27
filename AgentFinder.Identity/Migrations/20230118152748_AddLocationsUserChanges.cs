using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentFinder.Identity.Migrations
{
    public partial class AddLocationsUserChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Locations_AgentsInterestsLocations_AgentInterestsLocationId",
            //    table: "Locations");

            migrationBuilder.DropTable(
                name: "AgentsInterestsLocations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AgentInterestsLocationId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AgentInterestsLocationId",
                table: "Locations");

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsInBusiness = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agents_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_LocationId",
                table: "Agents",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.AddColumn<int>(
                name: "AgentInterestsLocationId",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgentsInterestsLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentsInterestsLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentsInterestsLocations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AgentInterestsLocationId",
                table: "Locations",
                column: "AgentInterestsLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentsInterestsLocations_UserId",
                table: "AgentsInterestsLocations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_AgentsInterestsLocations_AgentInterestsLocationId",
                table: "Locations",
                column: "AgentInterestsLocationId",
                principalTable: "AgentsInterestsLocations",
                principalColumn: "Id");
        }
    }
}
