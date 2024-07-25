using Microsoft.AspNetCore.Mvc;
using GD2.Services;

namespace GD2.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthenticationService  _authenticationService;

        public AccountController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Login()
        {
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
    }
}
