using BlazorApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void CreateBook(Book book)
        {
            Debug.WriteLine("Successfully entered function");
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>All books.</returns>
        public async Task<List<Book>> GetBooks()
        {
            

            return await Task.FromResult(new List<Book>());
        }

        /// <summary>
        /// Find a specific book.
        /// </summary>
        /// <param name="id">The book ID to look for.</param>
        /// <returns>The associated book.</returns>
        public async Task<Book> FindBook(int id)
        {
            return new Book();
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