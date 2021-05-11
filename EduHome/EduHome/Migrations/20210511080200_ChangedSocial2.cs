using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class ChangedSocial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Pinterest",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "SocialMedias");

            migrationBuilder.DropColumn(
                name: "Vimeo",
                table: "SocialMedias");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "SocialMedias",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "SocialMedias");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pinterest",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vimeo",
                table: "SocialMedias",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
