using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Book
    {
        /// <summary>
        /// Book ID. Primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Book title. Required.
        /// </summary>
        [Required(ErrorMessage = "Please enter a book title.")]
        public string Title { get; set; }

        /// <summary>
        /// Book description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Book author.
        /// </summary>
        [Required(ErrorMessage = "Please enter the book author.")]
        public string Author { get; set; }

        /// <summary>
        /// When the book is published?
        /// </summary>
        [Range(typeof(DateTime), minimum: "1/1/1801", maximum: "31/12/2051", ErrorMessage = "Date range must be between {1} and {2}")]
        public DateTime? PublishDate { get; set; }

        /// <summary>
        /// Is the book available for sale?
        /// </summary>

        public bool IsAvailable { get; set; }

        public Book()
        {

        }

        public Book(string title, string description, string author, DateTime? publishDate, bool isAvailable)
        {
            Title = title;
            Description = description;
            Author = author;
            PublishDate = publishDate;
            IsAvailable = isAvailable;
        }
    }
}