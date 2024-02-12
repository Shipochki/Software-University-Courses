using Homies.Models;
using System.ComponentModel.DataAnnotations;

namespace Homies.Services.Models
{
	public class EventAddModel
	{
		[Required]
		[MinLength(5)]
		[MaxLength(20)]
		public string Name { get; set; } = null!;

		[Required]
		[MinLength(15)]
		[MaxLength(150)]
		public string Description { get; set; } = null!;

		[Required]
		public string Start { get; set; } = null!;

		[Required]
		public string End { get; set; } = null!;

		[Required]
		public int TypeId { get; set; }

		public List<TypeViewModel>? Types { get; set; }
	}
}
