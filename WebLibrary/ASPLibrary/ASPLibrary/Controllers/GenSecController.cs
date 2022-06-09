using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPLibrary.Controllers
{
    public class GenSecController : Controller
    {
        [Authorize(Roles = "Gensec")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
