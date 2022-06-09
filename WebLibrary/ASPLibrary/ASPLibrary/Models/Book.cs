using System.ComponentModel.DataAnnotations;

namespace ASPLibrary.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Author { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(100)]
        public string Filename { get; set; }

        [Required]
        public virtual Category Category { get; set; }

    }
}