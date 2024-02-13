using Contacts.Models;
using Contacts.Services;
using Contacts.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

		[HttpGet]
		public  IActionResult Add()
		{
			ContactAddModel model = new ContactAddModel();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(ContactAddModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("All", "Contacts");
			}

			await this.contactService.AddContactAsync(model);

			return RedirectToAction("All", "Contacts");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int contactId) 
		{
			if(!ModelState.IsValid)
			{
				return RedirectToAction("All", "Contacts");
			}

			ContactEditModel model = await this.contactService.GetContactEditModelAsync(contactId);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int contactId ,ContactEditModel model)
		{
			await this.contactService.EditContactAsync(contactId, model);

			return RedirectToAction("All", "Contacts");
		}

		[HttpGet]
		public async Task<IActionResult> Team()
		{
			TeamContcatsViewModel model = new TeamContcatsViewModel();
			model.Contacts = await this.contactService.GetAllContactsInTeamAsync(GetUserId());

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddToTeam(int contactId)
		{
			await this.contactService.AddContactToTeamAsync(contactId, GetUserId());

			return RedirectToAction("Team", "Contacts");
		}

		[HttpPost]
		public async Task<IActionResult> RemoveFromTeam(int contactId)
		{
			await this.contactService.RemoveContactFromTeamAsync(contactId, GetUserId());

			return RedirectToAction("All", "Contacts");
		}

		private string GetUserId()
		   => User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
