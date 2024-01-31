using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Course_Signup_System.Migrations
{
    public partial class UpdateClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClassCode",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassCode",
                table: "Classes");
        }
    }
}
