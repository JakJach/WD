using Microsoft.EntityFrameworkCore;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class TeacherContext : DbContext
    {
        #region Constructors
        public TeacherContext(DbContextOptions<TeacherContext> options) : base(options)
        {
        }
        #endregion

        #region Fields
        public DbSet<Teacher> Teachers { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
