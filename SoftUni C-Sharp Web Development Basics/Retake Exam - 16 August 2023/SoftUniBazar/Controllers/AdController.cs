using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Models;
using SoftUniBazar.Services;
using SoftUniBazar.Services.Models;
using System.Security.Claims;

namespace SoftUniBazar.Controllers
{
    [Authorize]
	public class AdController : Controller
	{
		private readonly IAdService adService;
		private readonly ICategoryService categoryService;

        public AdController(IAdService _adService,
			ICategoryService _categoryService)
        {
			this.adService = _adService;
			this.categoryService = _categoryService;
        }

        public async Task<IActionResult> All()
		{
			List<AdAllViewModel> result = await adService.GetAllAsync();

			return View(result);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			AddAdModel model = new AddAdModel();
			model.Categories = await this.categoryService.GetAllCategoriesAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(AddAdModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("All", "Ad");
			}

			await this.adService.AddAdAsync(model, GetUserId());

			return RedirectToAction("All", "Ad");
		}

		private string GetUserId()
		   => User.FindFirstValue(ClaimTypes.NameIdentifier);
	}
}
