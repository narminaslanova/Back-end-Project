using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class ChangedSocial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_TeacherId",
                table: "SocialMedias");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_TeacherId",
                table: "SocialMedias",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_TeacherId",
                table: "SocialMedias");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_TeacherId",
                table: "SocialMedias",
                column: "TeacherId",
                unique: true);
        }
    }
}
