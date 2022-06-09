using ASPLibrary.Models;
using ASPLibrary.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;

namespace ASPLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly LeninLibraryContext context;
        private readonly IWebHostEnvironment appEnvironment;

        public HomeController(LeninLibraryContext context, IWebHostEnvironment appEnvironment)
        {
            this.context = context;
            this.appEnvironment = appEnvironment;
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
        [Authorize]
        public IActionResult Download(string filename)
        {
            var BooksPath = Path.Combine(appEnvironment.ContentRootPath, "Books");
            PhysicalFileProvider fileProvider = new PhysicalFileProvider(BooksPath);

            var file = fileProvider.GetFileInfo(filename);

            if (file.Exists)
            {
                return PhysicalFile(file.PhysicalPath, "application/octet-stream", file.Name);
            }
            else
            {
                return NotFound();
            }
        }
    }
}