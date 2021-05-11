using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class RelationToTeacherDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TeacherDetails");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Teachers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "TeacherDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherDetailsId",
                table: "Skills",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDetails_TeacherId",
                table: "TeacherDetails",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_TeacherDetailsId",
                table: "Skills",
                column: "TeacherDetailsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_TeacherDetails_TeacherDetailsId",
                table: "Skills",
                column: "TeacherDetailsId",
                principalTable: "TeacherDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDetails_Teachers_TeacherId",
                table: "TeacherDetails",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_TeacherDetails_TeacherDetailsId",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDetails_Teachers_TeacherId",
                table: "TeacherDetails");

            migrationBuilder.DropIndex(
                name: "IX_TeacherDetails_TeacherId",
                table: "TeacherDetails");

            migrationBuilder.DropIndex(
                name: "IX_Skills_TeacherDetailsId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "TeacherDetails");

            migrationBuilder.DropColumn(
                name: "TeacherDetailsId",
                table: "Skills");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TeacherDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
