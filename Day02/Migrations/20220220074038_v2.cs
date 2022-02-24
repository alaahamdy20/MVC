using Microsoft.EntityFrameworkCore.Migrations;

namespace Day02.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Imag",
                table: "Instractors",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Instractors",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "DName",
                table: "Departments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DManger",
                table: "Departments",
                newName: "Manger");

            migrationBuilder.RenameColumn(
                name: "DId",
                table: "Departments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Instractors",
                newName: "Imag");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Instractors",
                newName: "Adress");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "DName");

            migrationBuilder.RenameColumn(
                name: "Manger",
                table: "Departments",
                newName: "DManger");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Departments",
                newName: "DId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "CourseId");
        }
    }
}
