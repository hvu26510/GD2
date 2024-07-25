namespace GD2.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        // Quan hệ one-to-one với Cart
        public Cart Cart { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
