using Microsoft.EntityFrameworkCore.Migrations;

namespace WD.Web.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Theses_Students_StudentId",
                table: "Theses");

            migrationBuilder.DropIndex(
                name: "IX_Theses_StudentId",
                table: "Theses");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Theses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_Theses_StudentId",
                table: "Theses",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectStudent_StudentsUserID",
                table: "ProjectStudent",
                column: "StudentsUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_Students_StudentId",
                table: "Theses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Theses_Students_StudentId",
                table: "Theses");

            migrationBuilder.DropTable(
                name: "ProjectStudent");

            migrationBuilder.DropIndex(
                name: "IX_Theses_StudentId",
                table: "Theses");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "Theses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Theses_StudentId",
                table: "Theses",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Theses_Students_StudentId",
                table: "Theses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
