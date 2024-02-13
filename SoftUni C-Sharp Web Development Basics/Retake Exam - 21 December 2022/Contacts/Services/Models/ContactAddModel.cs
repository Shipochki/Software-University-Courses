using System.ComponentModel.DataAnnotations;

namespace Contacts.Services.Models
{
	public class ContactAddModel
	{
		[Required]
		[MinLength(2)]
		[MaxLength(50)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MinLength(5)]
		[MaxLength(50)]
		public string LastName { get; set; } = null!;

		[Required]
		[MinLength(10)]
		[MaxLength(60)]
		public string Email { get; set; } = null!;

		[Required]
		[MinLength(10)]
		[MaxLength(13)]
		[RegularExpression(@"([0][0-9]{9}||[+]359-[0-9]{3}-[0-9]{2}-[0-9]{2}-[0-9]{2}||[+]359 [0-9]{3} [0-9]{2} [0-9]{2} [0-9]{2}||[0] [0-9]{3} [0-9]{2} [0-9]{2} [0-9]{2})$")]
		public string PhoneNumber { get; set; } = null!;

		public string? Address { get; set; }

		[Required]
		[RegularExpression(@"www.[-a-zA-Z0-9]{1,256}.bg$")]
		public string? Website { get; set; }
	}
}
