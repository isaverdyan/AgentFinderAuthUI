using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentFinder.Identity.Migrations
{
    public partial class AddCustomerGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerGroupUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CustomerGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerGroupUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerGroupUsers_CustomerGroups_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "CustomerGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CustomerGroupUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OfferMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentId = table.Column<int>(type: "int", nullable: true),
                    CustomerGroupId = table.Column<int>(type: "int", nullable: true),
                    UserTypeId = table.Column<short>(type: "smallint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferMessages_CustomerGroups_CustomerGroupId",
                        column: x => x.CustomerGroupId,
                        principalTable: "CustomerGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferMessages_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OfferMessages_UserType_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserType",
                        principalColumn: "UserTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroupUsers_CustomerGroupId",
                table: "CustomerGroupUsers",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerGroupUsers_UserId",
                table: "CustomerGroupUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferMessages_AgentId",
                table: "OfferMessages",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferMessages_CustomerGroupId",
                table: "OfferMessages",
                column: "CustomerGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferMessages_UserTypeId",
                table: "OfferMessages",
                column: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerGroupUsers");

            migrationBuilder.DropTable(
                name: "OfferMessages");
        }
    }
}
