using BlazorApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Api.Repositories.Bookshelves
{
    public class BookshelfRepository : IBookshelfRepository
    {

        private readonly AppDbContext appDbContext;

        public BookshelfRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task AddBookShelf(Bookshelf bookshelf)
        {


            throw new NotImplementedException();
        }

        public Task DeleteBookshelf(int id)
        {
            var bookshelf = GetBookshelf(id);
            if(bookshelf is not null)
            {

            }

            throw new NotImplementedException();
        }

        public Task<Bookshelf> GetBookshelf(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bookshelf>> GetBookshelves()
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookshelf()
        {
            throw new NotImplementedException();
        }
    }
}