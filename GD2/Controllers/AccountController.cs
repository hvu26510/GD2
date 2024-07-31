using Microsoft.AspNetCore.Mvc;
using GD2.Services;
using GD2.Models;

namespace GD2.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthenticationService  _authenticationService;

        public AccountController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Login(string message = null)
        {
            ViewBag.ErrorMessage = message; 
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if(_authenticationService.Login(username, password))
            {
                return Redirect("/Home/Index");
            }
            ViewBag.ErrorMessage = "Thong tin dang nhap chua chinh xac";
            return View();
        }


        public IActionResult Profile()
        {
            Account user =  _authenticationService.GetCurrentUser();

            return View(user); 
        }
    }
}

