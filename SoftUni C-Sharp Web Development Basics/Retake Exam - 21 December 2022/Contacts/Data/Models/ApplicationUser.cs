using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public override string Id { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public override string UserName { get; set; } = null!;

        [Required]
        [MaxLength(60)]
        public override string Email { get; set; } = null!;

        [Required]
        public override string PasswordHash { get; set; } = null!;

        public List<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();
    }
}
