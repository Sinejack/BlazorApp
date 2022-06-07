using BlazorApp.Api.Repositories.Books;
using BlazorApp.Dto;
using BlazorApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            try
            {
                var result = await _bookRepository.GetBook(id);

                return result is not null
                    ? Ok(result)
                    : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving book from database: {ex.StackTrace}");
                throw;
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            try
            {
                var result = await _bookRepository.GetBooks();

                return result.Count > 0
                    ? Ok(await _bookRepository.GetBooks())
                    : NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving books from dataabse: {ex.StackTrace}");
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Book>> AddBook(BookDto book)
        {
            try
            {
                if (book is null)
                    return BadRequest();

                // Check if book exist

                var isExist = await _bookRepository.GetBookByTitle(book.Title);

                if (isExist is not null)
                    return Conflict($"A book with title \"{book.Title}\" already exist.");

                var newBook = new Book(
                    title: book.Title,
                    description: book.Description,
                    author: book.Author,
                    publishDate: book.PublishDate,
                    isAvailable: book.IsAvailable);

                var result = await _bookRepository.AddBook(newBook);

                return result != null
                    ? CreatedAtAction(nameof(GetBook), new { result.Id }, result)
                    : StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating books: {ex.StackTrace}");
                throw;
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();

                if (id != book.Id)
                    return BadRequest("Book ID does not match");

                var bookToUpdate = await _bookRepository.GetBook(id);

                if (bookToUpdate is null)
                    return NotFound();

                var result = await _bookRepository.UpdateBook(book);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating book: {ex.StackTrace}");
                throw;
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteBook(int id)
        {
            try
            {
                var bookToDelete = _bookRepository.GetBook(id);

                if (bookToDelete is null)
                    return NotFound();

                return Ok(await _bookRepository.DeleteBook(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting book: {ex.StackTrace}");
                throw;
            }
        }
    }
}