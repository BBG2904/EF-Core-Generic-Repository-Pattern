using EFCoreDatabase.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDatabase.Context
{
    public class OrderDBContext : DbContext
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options):base(options)
        {
            
        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Shop)
                .WithMany(s => s.Orders)
                .HasForeignKey(c => c.ShopId);                

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Orders)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(o => o.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(i => i.Items)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(o => o.ItemId);

            modelBuilder.Entity<Shop>().HasData(new Shop() { Id = 1, Address = "X", Name = "Swaraj" }, new Shop() { Id = 2, Address = "X", Name = "More" });
            modelBuilder.Entity<Item>().HasData(new Item() { Id = 1, Name = "Oil" }, new Item() { Id = 2, Name = "Dal" }, new Item()
            {
                Id = 3,
                Name = "Sugar"
            });
        }
    }
}
