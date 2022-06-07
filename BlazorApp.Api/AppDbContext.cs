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

        public DbSet<Bookshelf> Bookshelves { get; set; }

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
            var book = new Book
            {
                Id = 1,
                Author = "Janice Fools",
                Description = "A story about a long distance relationship",
                Title = "The Sun and The Moon",
                PublishDate = new DateTime(2021, 4, 14),
                IsAvailable = true
            };

            var bookshelf = new Bookshelf
            {
                Id = 1,
                Code = "A1",
                Condition = "Few scratches on the left board",
                Manufacturer = null,
                Length = 250,
                Width = 50,
                Height = 300
            };

            modelBuilder.Entity<Book>().HasData(book);
            modelBuilder.Entity<Bookshelf>().HasData(bookshelf);
        }
    }
}