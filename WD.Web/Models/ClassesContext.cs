using Microsoft.EntityFrameworkCore;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class ClassesContext : DbContext
    {
        #region Constructors
        public ClassesContext(DbContextOptions<ClassesContext> options) : base(options)
        {
        }
        #endregion

        #region Fields
        public DbSet<Classes> Classes { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
