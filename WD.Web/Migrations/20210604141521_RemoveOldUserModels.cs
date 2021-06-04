using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WD.Web.Migrations
{
    public partial class RemoveOldUserModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_TeacherUserID",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalNotes_Students_StudentId",
                table: "FinalNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Theses_Students_StudentId",
                table: "Theses");

            migrationBuilder.DropForeignKey(
                name: "FK_Theses_Teachers_PromoterId",
                table: "Theses");

            migrationBuilder.DropForeignKey(
                name: "FK_Theses_Teachers_ReviewerId",
                table: "Theses");

            migrationBuilder.DropTable(
                name: "ClassStudent");

            migrationBuilder.DropTable(
                name: "ProjectStudent");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Theses_PromoterId",
                table: "Theses");

            migrationBuilder.DropIndex(
                name: "IX_Theses_ReviewerId",
                table: "Theses");

            migrationBuilder.DropIndex(
                name: "IX_Theses_StudentId",
                table: "Theses");

            migrationBuilder.DropIndex(
                name: "IX_FinalNotes_StudentId",
                table: "FinalNotes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TeacherUserID",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "TeacherUserID",
                table: "Classes");

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
                columns: new[] { "CreationDate", "PromoterId", "ReviewerId", "StudentId", "TakeDate" },
                values: new object[] { new DateTime(2021, 6, 4, 16, 15, 20, 86, DateTimeKind.Local).AddTicks(6633), 0, null, null, new DateTime(2021, 6, 4, 16, 15, 20, 87, DateTimeKind.Local).AddTicks(1818) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeacherUserID",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    HasThesis = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CanBePromoter = table.Column<bool>(type: "bit", nullable: false),
                    CanBeReviewer = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudent",
                columns: table => new
                {
                    ClassesClassId = table.Column<int>(type: "int", nullable: false),
                    StudentsUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudent", x => new { x.ClassesClassId, x.StudentsUserID });
                    table.ForeignKey(
                        name: "FK_ClassStudent_Classes_ClassesClassId",
                        column: x => x.ClassesClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudent_Students_StudentsUserID",
                        column: x => x.StudentsUserID,
                        principalTable: "Students",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectStudent",
                columns: table => new
                {
                    ProjectsProjectId = table.Column<int>(type: "int", nullable: false),
                    StudentsUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStudent", x => new { x.ProjectsProjectId, x.StudentsUserID });
                    table.ForeignKey(
                        name: "FK_ProjectStudent_Projects_ProjectsProjectId",
                        column: x => x.ProjectsProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectStudent_Students_StudentsUserID",
                        column: x => x.StudentsUserID,
                        principalTable: "Students",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 5, 26, 12, 58, 43, 905, DateTimeKind.Local).AddTicks(6478));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { 1, "jakjach@student.agh.edu.pl", "Jakub", "42e7c00e8f7af060ba54331cd81b13a8", "Jachowicz" },
                    { 2, "alexbial@student.agh.edu.pl", "Alex", "124b63f14a3e2e080eb65521285f9611", "Białas" },
                    { 3, "matkas@student.agh.edu.pl", "Mateusz", "db4a311ab5789e9cdfafbec0f8e6bdc6", "Kasprzak" },
                    { 4, "rotter@agh.edu.pl", "Paweł", "18182f494c2d6cfdda3e893934b7ea5c", "Rotter" },
                    { 5, "baranowski@agh.edu.pl", "Jerzy", "25d8eb2adfa874aefccb40e132d95639", "Baranowski" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "UserID", "HasThesis" },
                values: new object[,]
                {
                    { 1, true },
                    { 2, true },
                    { 3, true }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "UserID", "CanBePromoter", "CanBeReviewer", "Title" },
                values: new object[,]
                {
                    { 4, true, true, null },
                    { 5, true, true, null }
                });

            migrationBuilder.UpdateData(
                table: "Theses",
                keyColumn: "ThesisId",
                keyValue: 1,
                columns: new[] { "CreationDate", "PromoterId", "ReviewerId", "StudentId", "TakeDate" },
                values: new object[] { new DateTime(2021, 5, 26, 12, 58, 43, 906, DateTimeKind.Local).AddTicks(8945), 4, 5, 1, new DateTime(2021, 5, 26, 12, 58, 43, 907, DateTimeKind.Local).AddTicks(1981) });

            migrationBuilder.CreateIndex(
                name: "IX_Theses_PromoterId",
                table: "Theses",
                column: "PromoterId");

            migrationBuilder.CreateIndex(
                name: "IX_Theses_ReviewerId",
                table: "Theses",
                column: "ReviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Theses_StudentId",
                table: "Theses",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FinalNotes_StudentId",
                table: "FinalNotes",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TeacherUserID",
                table: "Classes",
                column: "TeacherUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_StudentsUserID",
                table: "ClassStudent",
                column: "StudentsUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStudent_StudentsUserID",
                table: "ProjectStudent",
                column: "StudentsUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_TeacherUserID",
                table: "Classes",
                column: "TeacherUserID",
                principalTable: "Teachers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalNotes_Students_StudentId",
                table: "FinalNotes",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_Students_StudentId",
                table: "Theses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_Teachers_PromoterId",
                table: "Theses",
                column: "PromoterId",
                principalTable: "Teachers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_Teachers_ReviewerId",
                table: "Theses",
                column: "ReviewerId",
                principalTable: "Teachers",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
