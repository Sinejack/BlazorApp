using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Api.Repositories.Bookshelves
{
    public interface IBookshelfRepository
    {
        Task<IEnumerable<Bookshelf>> GetBookshelves();

        Task<Bookshelf> GetBookshelf(int id);

        Task AddBookShelf(Bookshelf bookshelf);

        Task UpdateBookshelf();

        Task DeleteBookshelf(int id);
    }
}