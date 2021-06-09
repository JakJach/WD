using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WD.Web.Migrations
{
    public partial class PrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThesisId",
                table: "Theses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Projects",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FileId",
                table: "Files",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ThesisFiles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StudentCourses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProjectStudents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProjectFiles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ThesisFiles",
                table: "ThesisFiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectStudents",
                table: "ProjectStudents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectFiles",
                table: "ProjectFiles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 9, 13, 2, 15, 147, DateTimeKind.Local).AddTicks(1440));

            migrationBuilder.UpdateData(
                table: "Theses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "TakeDate" },
                values: new object[] { new DateTime(2021, 6, 9, 13, 2, 15, 147, DateTimeKind.Local).AddTicks(5701), new DateTime(2021, 6, 9, 13, 2, 15, 147, DateTimeKind.Local).AddTicks(7905) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ThesisFiles",
                table: "ThesisFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentCourses",
                table: "StudentCourses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectStudents",
                table: "ProjectStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectFiles",
                table: "ProjectFiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ThesisFiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectStudents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectFiles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Theses",
                newName: "ThesisId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Projects",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Files",
                newName: "FileId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "CourseId");

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
    }
}
