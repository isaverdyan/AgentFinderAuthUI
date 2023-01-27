using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgentFinder.Identity.Migrations
{
    public partial class UpdateCustomerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastContactDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastContactDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "Customers");
        }
    }
}
