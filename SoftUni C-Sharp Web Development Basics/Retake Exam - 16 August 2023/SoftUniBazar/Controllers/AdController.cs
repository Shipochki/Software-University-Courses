using Microsoft.AspNetCore.Mvc;
using SoftUniBazar.Models;
using SoftUniBazar.Services;

namespace SoftUniBazar.Controllers
{
	public class AdController : Controller
	{
		private readonly IAdService adService;

        public AdController(IAdService _adService)
        {
			this.adService = _adService;
        }

        public async Task<IActionResult> All()
		{
			if (!User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Home");
			}

			List<AdAllViewModel> result = await adService.GetAllAsync();

			return View(result);
		}
	}
}
