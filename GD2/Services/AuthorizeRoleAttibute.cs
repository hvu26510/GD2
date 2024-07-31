using GD2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GD2.Services
{
    public class AuthorizeRoleAttibute : Attribute, IAuthorizationFilter
    {
        private readonly string[] roles;

        public AuthorizeRoleAttibute(params string[] roles)
        {
            this.roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Session.GetObjectFromJson<Account>("User");

            if (user == null) {
                context.Result = new RedirectToActionResult("Login", "Account", new { message = "Can dang nhap de truy cap."});
                return;
            }

            if (!roles.Any(role => user.UserRoles.Any(ur => ur.Role.Name == role)))
            {
                context.Result = new RedirectToActionResult("Login", "Account", new { message = "Can dang nhap dung account co quyen truy cap." });
            }

        }

    }
}
