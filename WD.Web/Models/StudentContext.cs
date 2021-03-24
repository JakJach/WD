using Microsoft.EntityFrameworkCore;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class StudentContext : DbContext
    {
        #region Constructors
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
        #endregion

        #region Fields
        public DbSet<Student> Students { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}
