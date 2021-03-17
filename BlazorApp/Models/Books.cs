using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Books
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsAvailable { get; set; }
    }
}