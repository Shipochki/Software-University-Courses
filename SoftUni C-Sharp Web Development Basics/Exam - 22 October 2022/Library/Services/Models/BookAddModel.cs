using Library.Data.Entites;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Library.Models;

namespace Library.Services.Models
{
    public class BookAddModel
    {  

        [Required]
        [MinLength(10)]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Author { get; set; } = null!;

        [Required]
        [MinLength(5)]
        [MaxLength(5000)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(0.00, 10.00)]
        public decimal Rating { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<CategoryViewModel>? Categories { get; set; }
    }
}
