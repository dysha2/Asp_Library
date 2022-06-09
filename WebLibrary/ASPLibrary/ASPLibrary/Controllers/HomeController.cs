using ASPLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly LeninLibraryContext context;

        public HomeController(LeninLibraryContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Books.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}