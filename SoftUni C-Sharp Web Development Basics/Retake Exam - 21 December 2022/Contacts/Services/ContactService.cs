using Contacts.Data;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Services
{
	public class ContactService : IContactService
	{
		private readonly ContactsDbContext context;

        public ContactService(ContactsDbContext _context)
        {
            context = _context;
        }

        public async Task<List<ContactViewModel>> GetAllContactsAsync()
		{
			return await this.context
				.Contacts
				.Select(c => new ContactViewModel()
				{
					ContactId = c.Id,
					FirstName = c.FirstName,
					LastName = c.LastName,
					Email = c.Email,
					Address = c.Address,
					PhoneNumber = c.PhoneNumber,
					Website = c.Website,
				})
				.ToListAsync();
		}
	}
}
