using Contacts.Models;
using Contacts.Services.Models;

namespace Contacts.Services
{
	public interface IContactService
	{
		Task<List<ContactViewModel>> GetAllContactsAsync();

		Task AddContactAsync(ContactAddModel model);

		Task EditContactAsync(int contactId,ContactEditModel model);

		Task AddContactToTeamAsync(int contactId, string userId);

		Task RemoveContactFromTeamAsync(int contactId, string userId);
		Task<List<ContactViewModel>> GetAllContactsInTeamAsync(string v);
		Task<ContactEditModel> GetContactEditModelAsync(int contactId);
	}
}
