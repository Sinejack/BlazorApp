using BlazorApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;

namespace BlazorApp.Services
{
    public class BooksService
    {
        private readonly Uri BaseAddress = new Uri("https://localhost:44317/");

        #region CRUD

        /// <summary>
        /// Create a new book.
        /// </summary>
        /// <param name="input"></param>
        public async Task<Book> CreateBook(Book book)
        {
            var jsonContent = JsonConvert.SerializeObject(book);
            var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            client.BaseAddress = BaseAddress;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsync("api/Books", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var repliedContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Book>(repliedContent);
            }

            return null;
        }

        /// <summary>
        /// Get all books.
        /// </summary>
        /// <returns>All books.</returns>
        public async Task<List<Book>> GetBooks()
        {
            // Get book from rest API

            var books = new List<Book>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;
                client.DefaultRequestHeaders.Accept.Clear();

                var response = await client.GetAsync("api/Books");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    books = JsonConvert.DeserializeObject<List<Book>>(content);
                }
            }

            return books;
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
        public async Task<Book> UpdateBook(int id, Book book)
        {

            return new Book();
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