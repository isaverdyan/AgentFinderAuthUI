using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentFinder.Identity.Migrations
{
    public partial class UserIdsCustomerChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentsInterestsLocations_Locations_LocationId",
                table: "AgentsInterestsLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_AgentsInterestsLocations_Users_userId",
                table: "AgentsInterestsLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroupUsers_Users_UserId",
                table: "CustomerGroupUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferMessages_Users_AgentId",
                table: "OfferMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId1",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgentsInterestsLocations",
                table: "AgentsInterestsLocations");

            migrationBuilder.DropIndex(
                name: "IX_AgentsInterestsLocations_userId",
                table: "AgentsInterestsLocations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserTypeId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "AgentsInterestsLocations");

            migrationBuilder.RenameTable(
                name: "AgentsInterestsLocations",
                newName: "AgentInterestsLocation");

            migrationBuilder.RenameIndex(
                name: "IX_AgentsInterestsLocations_LocationId",
                table: "AgentInterestsLocation",
                newName: "IX_AgentInterestsLocation_LocationId");

            migrationBuilder.AlterColumn<short>(
                name: "UserTypeId",
                table: "Users",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerRating",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FaceBook",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedIn",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecialSecription",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "CustomerGroupUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "AgentInterestsLocation",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgentInterestsLocation",
                table: "AgentInterestsLocation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsInBusiness = table.Column<int>(type: "int", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<short>(type: "smallint", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Agents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentInterestsLocation_UserId1",
                table: "AgentInterestsLocation",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_LocationId",
                table: "Agents",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_UserId",
                table: "Agents",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentInterestsLocation_Locations_LocationId",
                table: "AgentInterestsLocation",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentInterestsLocation_Users_UserId1",
                table: "AgentInterestsLocation",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroupUsers_Users_UserId",
                table: "CustomerGroupUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferMessages_Agents_AgentId",
                table: "OfferMessages",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgentInterestsLocation_Locations_LocationId",
                table: "AgentInterestsLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_AgentInterestsLocation_Users_UserId1",
                table: "AgentInterestsLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerGroupUsers_Users_UserId",
                table: "CustomerGroupUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferMessages_Agents_AgentId",
                table: "OfferMessages");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AgentInterestsLocation",
                table: "AgentInterestsLocation");

            migrationBuilder.DropIndex(
                name: "IX_AgentInterestsLocation_UserId1",
                table: "AgentInterestsLocation");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomerRating",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FaceBook",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LinkedIn",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SpecialSecription",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AgentInterestsLocation");

            migrationBuilder.RenameTable(
                name: "AgentInterestsLocation",
                newName: "AgentsInterestsLocations");

            migrationBuilder.RenameIndex(
                name: "IX_AgentInterestsLocation_LocationId",
                table: "AgentsInterestsLocations",
                newName: "IX_AgentsInterestsLocations_LocationId");

            migrationBuilder.AlterColumn<int>(
                name: "UserTypeId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<short>(
                name: "UserTypeId1",
                table: "Users",
                type: "smallint",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Customers",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CustomerGroupUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "AgentsInterestsLocations",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AgentsInterestsLocations",
                table: "AgentsInterestsLocations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId1",
                table: "Users",
                column: "UserTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId",
                table: "Customers",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerGroupUsers_Users_UserId",
                table: "CustomerGroupUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId",
                table: "Customers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferMessages_Users_AgentId",
                table: "OfferMessages",
                column: "AgentId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId1",
                table: "Users",
                column: "UserTypeId1",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId");
        }
    }
}
