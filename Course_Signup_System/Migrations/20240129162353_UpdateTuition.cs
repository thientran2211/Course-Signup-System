using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Migrations
{
    public partial class UpdateTuition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuitionFees_Classes_ClassId",
                table: "TuitionFees");

            migrationBuilder.DropForeignKey(
                name: "FK_TuitionFees_Students_StudentId",
                table: "TuitionFees");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TuitionFees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "TuitionFees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountTuition",
                table: "TuitionFees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalTuition",
                table: "TuitionFees",
                type: "float",
                nullable: true);
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuitionFees_Classes_ClassId",
                table: "TuitionFees");

            migrationBuilder.DropForeignKey(
                name: "FK_TuitionFees_Students_StudentId",
                table: "TuitionFees");

            migrationBuilder.DropColumn(
                name: "AmountTuition",
                table: "TuitionFees");

            migrationBuilder.DropColumn(
                name: "TotalTuition",
                table: "TuitionFees");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "TuitionFees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "TuitionFees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TuitionFees_Classes_ClassId",
                table: "TuitionFees",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_TuitionFees_Students_StudentId",
                table: "TuitionFees",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId");
        }
    }
}
