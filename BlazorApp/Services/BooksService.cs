using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class BooksService
    {
        #region CRUD

        /// <summary>
        /// Create a new book.
        /// </summary>
        /// <param name="input"></param>
        public void CreateBook(string input)
        {
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>All books.</returns>
        public async Task<List<Books>> GetBooks()
        {
            return await Task.FromResult(new List<Books>());
        }

        /// <summary>
        /// Find a specific book.
        /// </summary>
        /// <param name="id">The book ID to look for.</param>
        /// <returns>The associated book.</returns>
        public async Task<Books> FindBook(int id)
        {
            return new Books();
        }

        /// <summary>
        /// Update a book.
        /// </summary>
        public void UpdateBook()
        {
        }

        /// <summary>
        /// Delete a book.
        /// </summary>
        public void DeleteBook()
        {
        }

        #endregion CRUD
    }
}