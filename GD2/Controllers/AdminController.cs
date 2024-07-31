using GD2.Models;
using GD2.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace GD2.Controllers
{
    
    public class AdminController : Controller
    {
        [AuthorizeRoleAttibute("Admin", "Manager")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QuanLyUser()
        {
            return View();
        }
    }
}
