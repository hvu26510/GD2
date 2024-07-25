using GD2.Models;
using Microsoft.EntityFrameworkCore;
namespace GD2.Data
{
    public class GD2DbContext : DbContext
    {
        public GD2DbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductDetails)
                .WithOne(pd => pd.Product)
                .HasForeignKey(pd => pd.ProductId);

            // ProductDetail
            modelBuilder.Entity<ProductDetail>()
                .HasKey(pd => pd.Id);

            // Cart
            modelBuilder.Entity<Cart>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithOne(u => u.Cart)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Xóa cascade

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.CartDetails)
                .WithOne(cd => cd.Cart)
                .HasForeignKey(cd => cd.CartId);

            // CartDetail
            modelBuilder.Entity<CartDetail>()
                .HasKey(cd => cd.Id);

            modelBuilder.Entity<CartDetail>()
                .HasOne(cd => cd.ProductDetail)
                .WithMany()
                .HasForeignKey(cd => cd.ProductDetailId);

            // Order
            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);

            // OrderDetail
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => od.Id);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.ProductDetail)
                .WithMany()
                .HasForeignKey(od => od.ProductDetailId);

            // Account
            modelBuilder.Entity<Account>()
                .HasKey(a => a.Id);

            // Thiết lập mối quan hệ one-to-one với Cart
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Xóa cascade

            modelBuilder.Entity<Account>()
                .HasMany(a => a.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);

            // Role
            modelBuilder.Entity<Role>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.UserRoles)
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);

            // UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });
        }


    }
}
