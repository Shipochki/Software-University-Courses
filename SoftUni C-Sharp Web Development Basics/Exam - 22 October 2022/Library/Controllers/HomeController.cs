using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if(User != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("All", "Books");
            }

            return View();
        }
    }
}