using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<Student>().ToTable("Students").HasOne(s => s.Thesis).WithOne(t => t.Student);

            modelBuilder.Entity<Teacher>().ToTable("Teachers").HasMany(t => t.PromotedTheses).WithOne(t => t.Promoter).HasForeignKey(t => t.PromoterId);

            modelBuilder.Entity<Teacher>().ToTable("Teachers").HasMany(t => t.ReviewedTheses).WithOne(t => t.Reviewer).HasForeignKey(t => t.ReviewerId);

            modelBuilder.Entity<Class>().ToTable("Classes");

            modelBuilder.Entity<Project>().ToTable("Projects");

            modelBuilder.Entity<Thesis>().ToTable("Theses");

            modelBuilder.Entity<File>().ToTable("Files");

            modelBuilder.Entity<FinalNote>().ToTable("FinalNotes").HasKey(fn => fn.NoteId);

            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Thesis> Theses { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<FinalNote> FinalNotes { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
