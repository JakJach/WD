using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WD.Web.Migrations
{
    public partial class FloatNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ReviewerNote",
                table: "Theses",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "PromoterNote",
                table: "Theses",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Note",
                table: "Projects",
                type: "real",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Note",
                table: "FinalNotes",
                type: "real",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 5, 26, 0, 11, 28, 29, DateTimeKind.Local).AddTicks(2668));

            migrationBuilder.UpdateData(
                table: "Theses",
                keyColumn: "ThesisId",
                keyValue: 1,
                columns: new[] { "CreationDate", "TakeDate" },
                values: new object[] { new DateTime(2021, 5, 26, 0, 11, 28, 32, DateTimeKind.Local).AddTicks(6960), new DateTime(2021, 5, 26, 0, 11, 28, 32, DateTimeKind.Local).AddTicks(9055) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ReviewerNote",
                table: "Theses",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "PromoterNote",
                table: "Theses",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Note",
                table: "Projects",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "Note",
                table: "FinalNotes",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2021, 5, 26, 0, 0, 27, 702, DateTimeKind.Local).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "Theses",
                keyColumn: "ThesisId",
                keyValue: 1,
                columns: new[] { "CreationDate", "TakeDate" },
                values: new object[] { new DateTime(2021, 5, 26, 0, 0, 27, 705, DateTimeKind.Local).AddTicks(8260), new DateTime(2021, 5, 26, 0, 0, 27, 706, DateTimeKind.Local).AddTicks(419) });
        }
    }
}
