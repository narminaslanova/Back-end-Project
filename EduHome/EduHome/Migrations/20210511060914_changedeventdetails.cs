using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class changedeventdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description1",
                table: "EventDetails");

            migrationBuilder.DropColumn(
                name: "Description2",
                table: "EventDetails");

            migrationBuilder.DropColumn(
                name: "Description3",
                table: "EventDetails");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventDetails");

            migrationBuilder.AddColumn<string>(
                name: "Description1",
                table: "EventDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description2",
                table: "EventDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description3",
                table: "EventDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
