using Homies.Models;
using Homies.Services;
using Homies.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
	[Authorize]
	public class EventController : Controller
	{
		private readonly IEventService eventService;
		private readonly ITypeService typeService;

        public EventController(IEventService _eventService,
			ITypeService _typeService)
        {
            eventService = _eventService;
			typeService = _typeService;
        }

		[HttpGet]
        public async Task<IActionResult> All()
		{
			List<EventAllViewModel> result = await this.eventService.GetAllEventsAsync();

			return View(result);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			EventAddModel model = new EventAddModel();
			model.Types = await this.typeService.GetAllTypesAsync();

			return View(model);
		}

		[HttpPost]

		public async Task<IActionResult> Add(EventAddModel model)
		{
			if(!ModelState.IsValid)
			{
				return RedirectToAction("All", "Event");
			}

			await this.eventService.AddEventAsync(model, GetUserId());

			return RedirectToAction("All", "Event");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			if(!await this.eventService.IsOwnerAsync(id, GetUserId()))
			{
				return RedirectToAction("All", "Event");
			}

			EventEditModel model = await this.eventService.GetEventAsync(id);
			model.Types = await this.typeService.GetAllTypesAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, EventEditModel model)
		{
			if (!await this.eventService.IsOwnerAsync(id, GetUserId()))
			{
				return RedirectToAction("All", "Event");
			}

			if (!ModelState.IsValid)
			{
				return RedirectToAction("All", "Event");
			}

			await this.eventService.EditEventAsync(id, model);

			return RedirectToAction("All", "Event");
		}

		private string GetUserId()
		   => User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
