using Microsoft.EntityFrameworkCore;
using System;
using WD.Data.Models;

namespace WD.Web.Models
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    CourseId = 1,
                    Name = "Laboratorium Specjalizacyjne"
                },
                new Course
                {
                    CourseId = 2,
                    Name = "Seminarium Dyplomowe"
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 1,
                    Title = "Wirtualny Dziekanat",
                    CreationDate = DateTime.Now,
                    CourseId = 1,
                    IsReviewed = false,
                    IsSubmitted = false,
                    Review = null,
                    Scope = "Wykonanie aplikacji webowej obsługującej wirtualny dziekanat uczelni wyższej",
                    Goal = "Działająca i przetestowana aplikacja z funkcjonalnościami: dodawania ocen, oddawania projektów, składania pracy dyplomowej"
                });

            modelBuilder.Entity<Thesis>().HasData(
                new Thesis
                {
                    CreationDate = DateTime.Now,
                    IsAccepted = false,
                    IsReviewed = false,
                    IsSubmitted = false,
                    IsTaken = true,
                    TakeDate = DateTime.Now,
                    Review = null,
                    PromoterOpinion = null,
                    Title = "Wtyczka VST realizująca proces masteringu poprzez autmoatyczne dopasowanie korektora EQ",
                    Goal = "Wykonanie działającej  i gotowej do użycia wtyczki",
                    Scope = "Stowrzenie skryptów uczenia maszynowego, wykonanie biblioteki dll wykorzystującej wyniki działąnia ww. skryptów, wykonanie hosta",
                    StudentQualifications = "C#; Python",
                    ThesisId = 1
                });
        }
    }
}
