using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentFinder.Identity.Migrations
{
    public partial class UserChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_UserTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserTypeId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(short),
                oldType: "smallint",
                oldNullable: true);

            migrationBuilder.AddColumn<short>(
                name: "UserTypeId1",
                table: "Users",
                type: "smallint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId1",
                table: "Users",
                column: "UserTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_UserTypeId1",
                table: "Users",
                column: "UserTypeId1",
                principalTable: "UserType",
                principalColumn: "UserTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_UserTypeId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserTypeId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserTypeId1",
                table: "Users");

            migrationBuilder.AlterColumn<short>(
                name: "UserTypeId",
                table: "Users",
                type: "smallint",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserType",
                principalColumn: "UserTypeId");
        }
    }
}
