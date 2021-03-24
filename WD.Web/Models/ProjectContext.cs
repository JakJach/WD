using Microsoft.EntityFrameworkCore;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class ProjectContext : DbContext
    {
        #region Constructors
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
        }
        #endregion

        #region Fields
        public DbSet<Project> Projects { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
