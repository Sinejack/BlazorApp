using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Api.Repositories.Books
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();

        Task<Book> GetBook(int bookId);

        Task<Book> GetBookByTitle(string title);

        Task<Book> AddBook(Book book);

        Task<Book> UpdateBook(Book book);

        Task<Book> DeleteBook(int bookId);
    }
}