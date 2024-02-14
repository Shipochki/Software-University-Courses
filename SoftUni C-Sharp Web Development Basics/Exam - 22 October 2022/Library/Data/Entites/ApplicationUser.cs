using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Entites
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[MaxLength(20)]
		public override string UserName 
		{ 
			get => base.UserName; 
			set => base.UserName = value; 
		}

		[Required]
		[MaxLength(60)]
		public override string Email 
		{ 
			get => base.Email;
			set => base.Email = value; 
		}

		public List<ApplicationUserBook> ApplicationUsersBooks { get; set; } = new List<ApplicationUserBook>();
	}
}
