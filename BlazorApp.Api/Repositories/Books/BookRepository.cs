using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Api.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Book> AddBook(Book book)
        {
            var result = await appDbContext.Books.AddAsync(book);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Book> DeleteBook(int bookId)
        {
            var result = await GetBook(bookId);
            if (result != null)
            {
                appDbContext.Books.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Book> GetBook(int bookId)
        {
            return await appDbContext.Books.FirstOrDefaultAsync(x => x.Id == bookId);
        }

        public async Task<Book> GetBookByTitle(string title)
        {
            return await appDbContext.Books.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await appDbContext.Books.ToListAsync();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var result = await GetBook(book.Id);
            if (result != null)
            {
                result.Title = book.Title;
                result.Description = book.Description;
                result.Author = book.Author;
                result.PublishDate = book.PublishDate;
                result.IsAvailable = book.IsAvailable;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}