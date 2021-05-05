using Microsoft.EntityFrameworkCore;
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
        }
    }
}
