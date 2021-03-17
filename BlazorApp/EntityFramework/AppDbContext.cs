using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.EntityFramework
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        #region Models

        public DbSet<Books> Books { get; set; }

        #endregion Models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data (for testing purpose)

            SeedData(modelBuilder);
        }

        /// <summary>
        /// Function to seed data for testing purpose.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        private void SeedData(ModelBuilder modelBuilder)
        {

        }
    }
}