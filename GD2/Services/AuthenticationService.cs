using GD2.Data;
using GD2.Models;
using Microsoft.EntityFrameworkCore;

namespace GD2.Services
{
    public class AuthenticationService
    {
        private readonly GD2DbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string SessionUser = "User";

        public AuthenticationService(GD2DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public bool Login(string username, string password)
        {
            var user = _context.Accounts.Include(a => a.UserRoles)
                .ThenInclude(u => u.Role)
                .SingleOrDefault(a => a.UserName == username && a.PasswordHash == password);
            if (user == null) 
            { 
                return false;
            }

            //Luu thong tin user vao session
            _httpContextAccessor.HttpContext.Session.SetObjectAsJson(SessionUser, user);

            return true;
        }

        public Account GetCurrentUser()
        {
            return _httpContextAccessor.HttpContext.Session.GetObjectFromJson<Account>(SessionUser);
        }

    }
}
