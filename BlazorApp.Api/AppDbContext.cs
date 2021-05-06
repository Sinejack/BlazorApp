using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlazorApp.Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        #region Models

        public DbSet<Book> Books { get; set; }

        #endregion Models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            // Seed data (for testing purpose)

            SeedData(modelBuilder);
        }

        /// <summary>
        /// Function to seed data for testing purpose.
        /// </summary>
        /// <param name="modelBuilder">Model builder.</param>
        private void SeedData(ModelBuilder modelBuilder)
        {
            var book1 = new Book
            {
                Id = 1,
                Author = "Janice Fools",
                Description = "A story about a long distance relationship",
                Title = "The Sun and The Moon",
                PublishDate = new DateTime(2021, 4, 14),
                IsAvailable = true
            };

            modelBuilder.Entity<Book>().HasData(book1);
        }
    }
}