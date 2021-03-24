﻿using Microsoft.EntityFrameworkCore;
using WD.Data.Models;

namespace WD.Web.Models
{
    public class ThesisContext : DbContext
    {
        #region Constructors
        public ThesisContext(DbContextOptions<ThesisContext> options) : base(options)
        {
        }
        #endregion

        #region Fields
        public DbSet<Thesis> Theses { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}