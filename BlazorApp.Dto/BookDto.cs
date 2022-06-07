using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Dto
{
    public class BookDto
    {
        [Required]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(500)]
        public string Author { get; set; }

        public DateTime? PublishDate { get; set; }

        public bool IsAvailable { get; set; }
    }
}