﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WD.Data.Models;

namespace WD.Web.Models
{
    public partial class WDWebContext : IdentityDbContext
    {
        public WDWebContext(DbContextOptions<WDWebContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Courses");

            modelBuilder.Entity<File>().ToTable("Files");

            modelBuilder.Entity<Project>().ToTable("Projects");

            modelBuilder.Entity<ProjectFile>().ToTable("ProjectFiles").HasNoKey();

            modelBuilder.Entity<ProjectStudent>().ToTable("ProjectStudents").HasNoKey();

            modelBuilder.Entity<StudentCourses>().ToTable("StudentCourses").HasNoKey();

            modelBuilder.Entity<Thesis>().ToTable("Theses");

            modelBuilder.Entity<ThesisFile>().ToTable("ThesisFiles").HasNoKey();

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectFile> ProjectFiles { get; set; }
        public virtual DbSet<ProjectStudent> ProjectStudents { get; set; }
        public virtual DbSet<StudentCourses> StudentCourses { get; set; }
        public virtual DbSet<Thesis> Theses { get; set; }
        public virtual DbSet<ThesisFile> ThesisFiles { get; set; }
    }
}
