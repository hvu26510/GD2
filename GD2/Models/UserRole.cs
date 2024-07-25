namespace GD2.Models
{
    public class UserRole
    {
        public string UserId { get; set; }
        public Account User { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}
