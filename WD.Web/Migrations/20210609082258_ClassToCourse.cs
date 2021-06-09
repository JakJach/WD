using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WD.Web.Migrations
{
    public partial class ClassToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "StudentClasses");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Projects",
                newName: "CourseId");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    FinalNote = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Laboratorium Specjalizacyjne", null },
                    { 2, "Seminarium Dyplomowe", null }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 9, 10, 22, 57, 531, DateTimeKind.Local).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "Theses",
                keyColumn: "ThesisId",
                keyValue: 1,
                columns: new[] { "CreationDate", "TakeDate" },
                values: new object[] { new DateTime(2021, 6, 9, 10, 22, 57, 531, DateTimeKind.Local).AddTicks(8816), new DateTime(2021, 6, 9, 10, 22, 57, 532, DateTimeKind.Local).AddTicks(1092) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Projects",
                newName: "ClassId");

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "StudentClasses",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    FinalNote = table.Column<float>(type: "real", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Name", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Laboratorium Specjalizacyjne", null },
                    { 2, "Seminarium Dyplomowe", null }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 8, 1, 26, 27, 329, DateTimeKind.Local).AddTicks(6408));

            migrationBuilder.UpdateData(
                table: "Theses",
                keyColumn: "ThesisId",
                keyValue: 1,
                columns: new[] { "CreationDate", "TakeDate" },
                values: new object[] { new DateTime(2021, 6, 8, 1, 26, 27, 330, DateTimeKind.Local).AddTicks(195), new DateTime(2021, 6, 8, 1, 26, 27, 330, DateTimeKind.Local).AddTicks(2345) });
        }
    }
}
