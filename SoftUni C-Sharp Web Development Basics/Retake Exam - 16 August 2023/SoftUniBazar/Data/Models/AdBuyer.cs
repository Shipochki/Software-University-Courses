using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftUniBazar.Data.Models
{
	public class AdBuyer
	{
		[Required]
		[ForeignKey(nameof(User))]
		public string BuyerId { get; set; } = null!;
		public IdentityUser User { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Ad))]
		public int AdId { get; set; } 
		public Ad Ad { get; set; } = null!;
	}
}

//•	BuyerId – a  string, Primary Key, foreign key (required)
//•	Buyer – IdentityUser
//•	AdId – an integer, Primary Key, foreign key (required)
//•	Ad – Ad

