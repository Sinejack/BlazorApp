using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class Bookshelf
    {
        /// <summary>
        /// Bookshelf ID. Primary key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Bookshelf code. Required
        /// </summary>
        [Required(ErrorMessage = "Please enter the bookshelf code.")]
        public string Code { get; set; }

        /// <summary>
        /// Bookshelf manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// The condition of the bookshelf.
        /// </summary>
        [StringLength(1000)]
        public string Condition { get; set; }

        /// <summary>
        /// Bookshelf length in centimetre.
        /// </summary>
        [Range(minimum: 0.0d, maximum: double.MaxValue, ErrorMessage = "Length must be more than 0")]
        public double Length { get; set; }

        /// <summary>
        /// Bookshelf width in centimetre.
        /// </summary>
        [Range(minimum: 0.0d, maximum: double.MaxValue, ErrorMessage = "Width must be more than 0")]
        public double Width { get; set; }

        /// <summary>
        /// Bookshelf height in centimetre.
        /// </summary>
        [Range(minimum: 0.0d, maximum: double.MaxValue, ErrorMessage = "Height must be more than 0")]
        public double Height { get; set; }

        /// <summary>
        /// Bookshelf area.
        /// </summary>
        public double Area => Length * Width;

        /// <summary>
        /// Bookshelf volume
        /// </summary>
        public double Volume => Length * Width * Height;

        public Bookshelf()
        {

        }

        public Bookshelf(string code, string manufacturer, string condition, double length, double width, double height)
        {
            Code = code;
            Manufacturer = manufacturer;
            Condition = condition;
            Length = length;
            Width = width;
            Height = height;
        }
    }
}