using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SeminarHub.Models;
using SeminarHub.Services;
using SeminarHub.Services.Models;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
	[Authorize]
	public class SeminarController : Controller
	{
		private readonly ISeminarService seminarService;
		private readonly ICategoryService categoryService;

		public SeminarController(
			ISeminarService _seminarService,
			ICategoryService _categoryService)
		{
			seminarService = _seminarService;
			categoryService = _categoryService;
		}

		public async Task<IActionResult> All()
		{
			List<AllSeminarViewModel> models = await this.seminarService.GetAllSeminarsAsync();
			return View(models);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			AddSeminarModel model = new AddSeminarModel();
			model.Categories = await this.categoryService.GetAllCategoriesAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddSeminarModel model)
		{
			if (!ModelState.IsValid)
			{
				return View("Add", model);
			}

			await this.seminarService.AddSeminarAsync(model, GetUserId());

			return RedirectToAction("All", "Seminar");
		}

		[HttpPost]
		public async Task<IActionResult> Join(int id)
		{
			bool result = await this.seminarService.JoinSeminarAsync(id, GetUserId());

			if (!result)
			{
				return RedirectToAction("All", "Seminar");
			}

			return RedirectToAction("Joined", "Seminar");
		}

		[HttpPost]
		public async Task<IActionResult> Leave(int id)
		{
			await this.seminarService.LeaveSeminarAsync(id, GetUserId());

			return RedirectToAction("Joined", "Seminar");
		}


		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			EditSeminarModel model = new EditSeminarModel();

			try
			{
				model = await this.seminarService.GetSeminarAsync(id, GetUserId());
			}
			catch (ArgumentException m)
			{
                await Console.Out.WriteLineAsync(m.Message);
				return Unauthorized();
            }

			if(model == null)
			{
				return RedirectToAction("All", "Seminar");
			}

			model.Categories = await this.categoryService.GetAllCategoriesAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, EditSeminarModel model)
		{
			if (!ModelState.IsValid)
			{
				return View("Edit", new { id, model });
			}

			await this.seminarService.EditSeminarAsync(id, model, GetUserId());

			return RedirectToAction("All", "Seminar");
		}

		[HttpGet]
		public async Task<IActionResult> Joined()
		{
			List<AllSeminarViewModel> models = await this.seminarService.GetAllJoindedSeminarsAsync(GetUserId());

			return View(models);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			DetailsSeminarViewModel model = await this.seminarService.GetDetailsSeminarAsync(id);

			if(model == null)
			{
				return RedirectToAction("All", "Seminar");
			}

			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			DeleteSeminarViewModel model = new DeleteSeminarViewModel();
			try
			{
				model = await this.seminarService.GetDeleteSeminarAsync(id, GetUserId());
			}
			catch (ArgumentException m)
			{
				await Console.Out.WriteLineAsync(m.Message);
				return Unauthorized();
			}

			if(model == null)
			{
				return RedirectToAction("All", "Seminar");
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await this.seminarService.DeleteSeminarAsync(id, GetUserId());

			return RedirectToAction("All", "Seminar");
		}

		private string GetUserId()
		   => User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
