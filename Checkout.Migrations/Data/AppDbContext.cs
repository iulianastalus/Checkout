using Checkout.Migrations.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Checkout.Migrations
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Store;User Id=sa;Password=P@ssword123!@#;");
        }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}