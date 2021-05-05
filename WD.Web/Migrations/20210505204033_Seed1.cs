using Microsoft.EntityFrameworkCore.Migrations;

namespace WD.Web.Migrations
{
    public partial class Seed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Name", "Password", "Surname" },
                values: new object[] { 1, "jakjach@student.agh.edu.pl", "Jakub", "jakjach", "Jachowicz" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Name", "Password", "Surname" },
                values: new object[] { 2, "alexbial@student.agh.edu.pl", "Alex", "alexbial", "Białas" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Name", "Password", "Surname" },
                values: new object[] { 3, "matkas@student.agh.edu.pl", "Mateusz", "matkas", "Kasprzak" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "UserID", "HasThesis" },
                values: new object[] { 1, true });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "UserID", "HasThesis" },
                values: new object[] { 2, true });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "UserID", "HasThesis" },
                values: new object[] { 3, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "UserID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 3);
        }
    }
}
