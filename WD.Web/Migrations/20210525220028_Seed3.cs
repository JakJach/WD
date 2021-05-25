using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WD.Web.Migrations
{
    public partial class Seed3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "Name", "TeacherUserID" },
                values: new object[,]
                {
                    { 1, "Laboratorium Specjalizacyjne", null },
                    { 2, "Seminarium Dyplomowe", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "Name", "Password", "Surname" },
                values: new object[,]
                {
                    { 4, "rotter@agh.edu.pl", "Paweł", "18182f494c2d6cfdda3e893934b7ea5c", "Rotter" },
                    { 5, "baranowski@agh.edu.pl", "Jerzy", "25d8eb2adfa874aefccb40e132d95639", "Baranowski" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "ClassId", "CreationDate", "Goal", "IsReviewed", "IsSubmitted", "Note", "Review", "ReviewDate", "Scope", "SubmissionDate", "Title" },
                values: new object[] { 1, 1, new DateTime(2021, 5, 26, 0, 0, 27, 702, DateTimeKind.Local).AddTicks(3289), "Działająca i przetestowana aplikacja z funkcjonalnościami: dodawania ocen, oddawania projektów, składania pracy dyplomowej", false, false, null, null, null, "Wykonanie aplikacji webowej obsługującej wirtualny dziekanat uczelni wyższej", null, "Wirtualny Dziekanat" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "UserID", "CanBePromoter", "CanBeReviewer", "Title" },
                values: new object[] { 4, true, true, null });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "UserID", "CanBePromoter", "CanBeReviewer", "Title" },
                values: new object[] { 5, true, true, null });

            migrationBuilder.InsertData(
                table: "Theses",
                columns: new[] { "ThesisId", "AcceptationDate", "CreationDate", "Goal", "IsAccepted", "IsReviewed", "IsSubmitted", "IsTaken", "PromoterId", "PromoterNote", "PromoterOpinion", "Review", "ReviewDate", "ReviewerId", "ReviewerNote", "Scope", "StudentId", "StudentQualifications", "SubmissionDate", "TakeDate", "Title" },
                values: new object[] { 1, null, new DateTime(2021, 5, 26, 0, 0, 27, 705, DateTimeKind.Local).AddTicks(8260), "Wykonanie działającej  i gotowej do użycia wtyczki", false, false, false, true, 4, null, null, null, null, 5, null, "Stowrzenie skryptów uczenia maszynowego, wykonanie biblioteki dll wykorzystującej wyniki działąnia ww. skryptów, wykonanie hosta", 1, "C#; Python", null, new DateTime(2021, 5, 26, 0, 0, 27, 706, DateTimeKind.Local).AddTicks(419), "Wtyczka VST realizująca proces masteringu poprzez autmoatyczne dopasowanie korektora EQ" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Theses",
                keyColumn: "ThesisId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "UserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "UserID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 5);
        }
    }
}
