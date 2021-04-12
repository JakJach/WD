using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class WDContext : IdentityDbContext
    {
        public WDContext(DbContextOptions<WDContext> options) : base(options)
        {

        }

        public DbSet<User> AllUsers { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Thesis> Theses { get; set; }
    }
}
