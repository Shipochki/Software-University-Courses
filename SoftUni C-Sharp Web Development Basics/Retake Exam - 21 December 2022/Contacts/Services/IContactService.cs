using Contacts.Models;

namespace Contacts.Services
{
	public interface IContactService
	{
		Task<List<ContactViewModel>> GetAllContactsAsync();
	}
}
