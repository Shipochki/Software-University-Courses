using SoftUniBazar.Models;
using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Services.Models
{
	public class EditAdModel
	{
		[Required]
		[MinLength(5)]
		[MaxLength(25)]
		public string Name { get; set; } = null!;

		[Required]
		[MinLength(15)]
		[MaxLength(250)]
		public string Description { get; set; } = null!;

		[Required]
		public string ImageUrl { get; set; } = null!;

		[Required]
		public decimal Price { get; set; }

		[Required]
		public int CategoryId { get; set; }

		public List<CategoryViewModel>? Categories { get; set; }
	}
}
