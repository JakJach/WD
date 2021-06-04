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
            modelBuilder.Entity<Class>().ToTable("Classes");

            modelBuilder.Entity<Project>().ToTable("Projects");

            modelBuilder.Entity<Thesis>().ToTable("Theses");

            modelBuilder.Entity<File>().ToTable("Files");

            modelBuilder.Entity<FinalNote>().ToTable("FinalNotes").HasKey(fn => fn.NoteId);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Thesis> Theses { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<FinalNote> FinalNotes { get; set; }
    }
}
