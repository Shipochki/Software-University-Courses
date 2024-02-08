using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Data.Models
{
	public class AdBuyer
	{
		public string BuyerId { get; set; } = null!;

		public IdentityUser User { get; set; } = null!;

		public int AdId { get; set; } 

		public Ad Ad { get; set; } = null!;
	}
}

//•	BuyerId – a  string, Primary Key, foreign key (required)
//•	Buyer – IdentityUser
//•	AdId – an integer, Primary Key, foreign key (required)
//•	Ad – Ad

