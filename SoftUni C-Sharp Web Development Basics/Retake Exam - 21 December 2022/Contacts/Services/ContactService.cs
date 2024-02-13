using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Models;
using Contacts.Services.Models;
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

		public async Task AddContactAsync(ContactAddModel model)
		{
			Contact contact = new Contact()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				Address = model.Address,
				PhoneNumber = model.PhoneNumber,
				Website = model.Website,
			};

			await this.context.Contacts.AddAsync(contact);
			await this.context.SaveChangesAsync();
		}

		public async Task AddContactToTeamAsync(int contactId, string userId)
		{
			Contact? contact = await this.context.Contacts.FindAsync(contactId);

			if (contact == null)
			{
				return;
			}

			ApplicationUserContact? applicationUserContact = await this.context
				.ApplicationUsersContacts
				.Where(a => a.ContactId == contactId && a.ApplicationUserId == userId)
				.FirstOrDefaultAsync();

			if (applicationUserContact != null)
			{
				return;
			}

			applicationUserContact = new ApplicationUserContact()
			{
				ApplicationUserId = userId,
				Contact = contact,
				ContactId = contactId,
			};

			await this.context.ApplicationUsersContacts.AddAsync(applicationUserContact);
			await this.context.SaveChangesAsync();
		}

		public async Task EditContactAsync(int contactId, ContactEditModel model)
		{
			Contact? contact = await this.context.Contacts.FindAsync(contactId);

			if (contact == null)
			{
				return;
			}

			contact.FirstName = model.FirstName;
			contact.LastName = model.LastName;
			contact.Email = model.Email;
			contact.Address = model.Address;
			contact.PhoneNumber = model.PhoneNumber;
			contact.Website = model.Website;

			await this.context.SaveChangesAsync();
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

		public async Task<List<ContactViewModel>> GetAllContactsInTeamAsync(string userId)
		{
			return await this.context
				.ApplicationUsersContacts
				.Where(a => a.ApplicationUserId == userId)
				.Select(a => new ContactViewModel()
				{
					ContactId = a.Contact.Id,
					FirstName = a.Contact.FirstName,
					LastName = a.Contact.LastName,
					Email = a.Contact.Email,
					Address = a.Contact.Address,
					PhoneNumber = a.Contact.PhoneNumber,
					Website = a.Contact.Website,
				})
				.ToListAsync();
		}

		public async Task<ContactEditModel> GetContactEditModelAsync(int contactId)
		{
			ContactEditModel? model = await this.context
				.Contacts
				.Where(c => c.Id == contactId)
				.Select(c => new ContactEditModel()
				{
					FirstName = c.FirstName,
					LastName = c.LastName,
					Email = c.Email,
					Address = c.Address,
					PhoneNumber = c.PhoneNumber,
					Website = c.Website,
				})
				.FirstOrDefaultAsync();

			if (model == null)
			{
				return null;
			}

			return model;
		}

		public async Task RemoveContactFromTeamAsync(int contactId, string userId)
		{
			ApplicationUserContact? applicationUserContact = await this.context
				.ApplicationUsersContacts
				.Where(c => c.ContactId == contactId && c.ApplicationUserId == userId)
				.FirstOrDefaultAsync();

			if (applicationUserContact == null)
			{
				return;
			}

			this.context.ApplicationUsersContacts.Remove(applicationUserContact);
			await this.context.SaveChangesAsync();
		}
	}
}
