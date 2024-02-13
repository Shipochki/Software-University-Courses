using Contacts.Models;
using Contacts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contacts.Controllers
{
	[Authorize]
	public class ContactsController : Controller
	{
		private readonly IContactService contactService;

        public ContactsController(IContactService _contactService)
        {
            contactService = _contactService;
        }

        public async Task<IActionResult> All()
		{
			AllContactsViewModel viewModel = new AllContactsViewModel();
			viewModel.Contacts = await this.contactService.GetAllContactsAsync();

			return View(viewModel);
		}
	}
}
