using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WD.Web.Migrations
{
    public partial class ModelsRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Projects_ProjectId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Files_Theses_ThesisId",
                table: "Files");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Classes_ClassId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "FinalNotes");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClassId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Files_ProjectId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_ThesisId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "ThesisId",
                table: "Files");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "Theses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReviewerId",
                table: "Theses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PromoterId",
                table: "Theses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectFiles",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ProjectStudents",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "StudentClasses",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    FinalNote = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ThesisFiles",
                columns: table => new
                {
                    ThesisId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
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
                columns: new[] { "CreationDate", "PromoterId", "TakeDate" },
                values: new object[] { new DateTime(2021, 6, 8, 1, 26, 27, 330, DateTimeKind.Local).AddTicks(195), null, new DateTime(2021, 6, 8, 1, 26, 27, 330, DateTimeKind.Local).AddTicks(2345) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFiles");

            migrationBuilder.DropTable(
                name: "ProjectStudents");

            migrationBuilder.DropTable(
                name: "StudentClasses");

            migrationBuilder.DropTable(
                name: "ThesisFiles");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Classes");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Theses",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReviewerId",
                table: "Theses",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PromoterId",
                table: "Theses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThesisId",
                table: "Files",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FinalNotes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<float>(type: "real", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalNotes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_FinalNotes_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 6, 4, 16, 15, 20, 85, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "Theses",
                keyColumn: "ThesisId",
                keyValue: 1,
                columns: new[] { "CreationDate", "PromoterId", "TakeDate" },
                values: new object[] { new DateTime(2021, 6, 4, 16, 15, 20, 86, DateTimeKind.Local).AddTicks(6633), 0, new DateTime(2021, 6, 4, 16, 15, 20, 87, DateTimeKind.Local).AddTicks(1818) });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClassId",
                table: "Projects",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ProjectId",
                table: "Files",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ThesisId",
                table: "Files",
                column: "ThesisId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalNotes_ClassId",
                table: "FinalNotes",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Projects_ProjectId",
                table: "Files",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Theses_ThesisId",
                table: "Files",
                column: "ThesisId",
                principalTable: "Theses",
                principalColumn: "ThesisId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Classes_ClassId",
                table: "Projects",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
