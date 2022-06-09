using ASPLibrary.Models;
using ASPLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ASPLibrary.Controllers
{
    public class UserController : Controller
    {
        private readonly LeninLibraryContext _context;

        public UserController(LeninLibraryContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserVM userVM) // async
        {
            if (!ModelState.IsValid)
            {
                return View(userVM);
            }

            userVM.Username = userVM.Username.ToLower().Trim();

            User user = _context.Users
                .FirstOrDefault(u =>
                    u.Username == userVM.Username &&
                    u.Password == userVM.Password);

            if (user == null)
            {
                ModelState.AddModelError("invalid user", "Неверное имя пользователя или пароль!");
                return View(userVM);
            }

            await Auth(user); // await

            return RedirectToAction("Index", "Home"); // redirect на стартовую страницу
        }


        private async Task Auth(User user)
        {
            // определим свои значения claims
            List<Claim> claims = new List<Claim>
            {
                new Claim("username", user.Username),
                new Claim("role", Enum.GetName(user.Role)),
                new Claim("Key", "Value")
            };

            // используем их для создания ClaimsIdentity
            var identity = new ClaimsIdentity(claims, "mycookie", "username", "role");
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync("mycookie", principal);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
