using Microsoft.EntityFrameworkCore;
using System;
using WD.Data.Models;
using WD.Data.Tools;

namespace WD.Web.Models
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    UserID = 1,
                    Name = "Jakub",
                    Surname = "Jachowicz",
                    Email = "jakjach@student.agh.edu.pl",
                    Password = PasswordHasher.GetHashedPassword("jakjach"),
                    HasThesis = true
                },
                new Student
                {
                    UserID = 2,
                    Name = "Alex",
                    Surname = "Białas",
                    Email = "alexbial@student.agh.edu.pl",
                    Password = PasswordHasher.GetHashedPassword("alexbial"),
                    HasThesis = true
                },
                new Student
                {
                    UserID = 3,
                    Name = "Mateusz",
                    Surname = "Kasprzak",
                    Email = "matkas@student.agh.edu.pl",
                    Password = PasswordHasher.GetHashedPassword("matkas"),
                    HasThesis = true
                });

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    UserID = 4,
                    Name = "Paweł",
                    Surname = "Rotter",
                    CanBePromoter = true,
                    CanBeReviewer = true,
                    Email = "rotter@agh.edu.pl",
                    Password = PasswordHasher.GetHashedPassword("rotter")
                },
                new Teacher
                {
                    UserID = 5,
                    Name = "Jerzy",
                    Surname = "Baranowski",
                    CanBePromoter = true,
                    CanBeReviewer = true,
                    Email = "baranowski@agh.edu.pl",
                    Password = PasswordHasher.GetHashedPassword("baranowski")
                });

            modelBuilder.Entity<Class>().HasData(
                new Class
                {
                    ClassId = 1,
                    Name = "Laboratorium Specjalizacyjne"
                },
                new Class
                {
                    ClassId = 2,
                    Name = "Seminarium Dyplomowe"
                });

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    ProjectId = 1,
                    Title = "Wirtualny Dziekanat",
                    CreationDate = DateTime.Now,
                    ClassId = 1,
                    IsReviewed = false,
                    IsSubmitted = false,
                    SubmissionDate = null,
                    ReviewDate = null,
                    Review = null,
                    Note = null,
                    Scope = "Wykonanie aplikacji webowej obsługującej wirtualny dziekanat uczelni wyższej",
                    Goal = "Działająca i przetestowana aplikacja z funkcjonalnościami: dodawania ocen, oddawania projektów, składania pracy dyplomowej"
                });

            modelBuilder.Entity<Thesis>().HasData(
                new Thesis
                {
                    StudentId = 1,
                    SubmissionDate = null,
                    AcceptationDate = null,
                    CreationDate = DateTime.Now,
                    IsAccepted = false,
                    IsReviewed = false,
                    IsSubmitted = false,
                    IsTaken = true,
                    TakeDate = DateTime.Now,
                    ReviewDate = null,
                    Review = null,
                    PromoterId = 4,
                    ReviewerId = 5,
                    PromoterNote = null,
                    ReviewerNote = null,
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
