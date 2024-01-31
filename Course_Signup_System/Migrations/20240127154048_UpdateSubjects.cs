using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Migrations
{
    public partial class UpdateSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_LecturingSchedules_LecturingScheduleId",
                table: "Subjects");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_LecturingScheduleId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "LecturingScheduleId",
                table: "Subjects");

            migrationBuilder.CreateIndex(
                name: "IX_LecturingSchedules_SubjectId",
                table: "LecturingSchedules",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_LecturingSchedules_Subjects_SubjectId",
                table: "LecturingSchedules",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LecturingSchedules_Subjects_SubjectId",
                table: "LecturingSchedules");

            migrationBuilder.DropIndex(
                name: "IX_LecturingSchedules_SubjectId",
                table: "LecturingSchedules");

            migrationBuilder.AddColumn<int>(
                name: "LecturingScheduleId",
                table: "Subjects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_LecturingScheduleId",
                table: "Subjects",
                column: "LecturingScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_LecturingSchedules_LecturingScheduleId",
                table: "Subjects",
                column: "LecturingScheduleId",
                principalTable: "LecturingSchedules",
                principalColumn: "Id");
        }
    }
}
