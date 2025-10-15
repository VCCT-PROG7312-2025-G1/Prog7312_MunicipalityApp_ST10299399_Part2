using Microsoft.AspNetCore.Mvc;
using Prog7312_MunicipalityApp_ST10299399.Data;

namespace Prog7312_MunicipalityApp_ST10299399.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        // Constructor with dependency injection for database context   
        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        // Handles user login
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Role", user.Role);
                return RedirectToAction("Index", "Event");
            }
            ViewBag.Error = "Invalid username or password";
            return View();
        }
        // Handles user logout

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
