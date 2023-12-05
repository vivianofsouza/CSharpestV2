using CSharpestServer.Models;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Identity.Client;



public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

    public DbSet<Item> items { get; set; }

    public DbSet<Bundle> bundles { get; set; }
    
    public DbSet<CartItem> cartItems { get; set; }
    
    public DbSet<Cart> carts { get; set; }
    
    public DbSet<User> users { get; set; }
    
    public DbSet<Order> orders { get; set; }
    
    public DbSet<OrderItem> orderItems { get; set; }
    
    public DbSet<Card> cards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().HasKey(x => x.Id);
        modelBuilder.Entity<Bundle>().HasKey(x => x.Id);
        modelBuilder.Entity<CartItem>().HasKey(x => x.Id);
        modelBuilder.Entity<Cart>().HasKey(x => x.Id);
        modelBuilder.Entity<User>().HasKey(x => x.Id);
        modelBuilder.Entity<OrderItem>().HasKey(x => x.Id);
        modelBuilder.Entity<Order>().HasKey(x => x.Id);
        modelBuilder.Entity<Card>().HasKey(x => x.Number);            
        // Other configurations...
    }

}