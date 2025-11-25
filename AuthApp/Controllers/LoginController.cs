using AuthApp.Data;
using AuthApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AuthApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoginController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
            if (account == null)
            {
                ViewBag.Username = "";
                ViewBag.Error("Wrong username or password");
                return View("Error");
            }
            else
            {
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Fullname", account.Fullname);
                HttpContext.Session.SetInt32("AccountId", Convert.ToInt32(account.Id));
                ViewBag.Username = username;
                return View("Success");
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("Username");
            if ( username != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }    
        }
    }
}
