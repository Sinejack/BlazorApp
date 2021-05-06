using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Api.Repositories.Books
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooks();

        Task<Book> GetBook(int bookId);

        Task<Book> AddBook(Book book);

        Task<Book> UpdateBook(Book book);

        Task DeleteBook(int bookId);
    }
}