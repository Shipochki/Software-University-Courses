using System.ComponentModel.DataAnnotations;

namespace SoftUniBazar.Data.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(15)]
		public string Name { get; set; } = null!;

		public List<Ad> Ads { get; set; } = new List<Ad>();
	}
}

//•	Has Id – a unique integer, Primary Key
//•	Has Name – a string with min length 3 and max length 15 (required)
//•	Has Ads – a collection of type Ad
