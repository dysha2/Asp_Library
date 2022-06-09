using ASPLibrary.Models;
using ASPLibrary.ViewModels;
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
            IndexVM indexVM = new IndexVM();
            indexVM.Categories = context.Categories.ToList();
            indexVM.Books = context.Books.ToList();
            return View(indexVM);
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