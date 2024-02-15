using Library.Models;
using Library.Services;
using Library.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Library.Controllers
{
	[Authorize]
	public class BooksController : Controller
	{
		private readonly IBookService bookService;

        public BooksController(IBookService _bookService)
        {
            bookService = _bookService;
        }

		[HttpGet]
        public async Task<IActionResult> All()
		{
			List<BookAllViewModel> models = await this.bookService.GetAllBooksAsync();

			return View(models);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			BookAddModel model = new BookAddModel();
			model.Categories = await this.bookService.GetAllCategoriesAsync();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(BookAddModel model)
		{
			if (!ModelState.IsValid)
			{
				return RedirectToAction("All", "Books");
			}

			await this.bookService.AddBookAsync(model);

			return RedirectToAction("All", "Books");
		}

		[HttpGet]
		public async Task<IActionResult> Mine()
		{
			List<BookMineViewModel> models = new List<BookMineViewModel>();
			try
			{
				 models = await this.bookService.GetAllMineBookAsync(GetUserId());
			}
			catch (ArgumentException m)
			{
                await Console.Out.WriteLineAsync(m.Message);
				return RedirectToAction("All", "Books");
            }

			return View(models);
		}

		[HttpPost]
		public async Task<IActionResult> AddToCollection(int bookId)
		{
			try
			{
				await this.bookService.AddBookToMineAsync(bookId, GetUserId());
			}
			catch (ArgumentException m)
			{
                await Console.Out.WriteLineAsync(m.Message);
                return RedirectToAction("All", "Books");
			}

			return RedirectToAction("Mine", "Books");
		}

		[HttpPost]
		public async Task<IActionResult> RemoveFromCollection(int bookId)
		{
			try
			{
                await this.bookService.RemoveBookFromMineAsync(bookId, GetUserId());
            }
			catch (ArgumentException m)
			{
                await Console.Out.WriteLineAsync(m.Message);
				return RedirectToAction("All", "Books");
            }

			return RedirectToAction("All", "Books");
		}

        private string GetUserId()
           => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
