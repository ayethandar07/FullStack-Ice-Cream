using IceCream.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace IceCream.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<IceCreams> IceCreams {  get; set; }
    public DbSet<IceCreamOption> IceCreamOptions {  get; set; }
    public DbSet<Order> Orders {  get; set; }
    public DbSet<OrderItem> OrderItems {  get; set; }
    public DbSet<User> Users {  get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IceCreamOption>()
            .HasKey(io => new { io.IceCreamId, io.Flavor, io.Topping });

        AddSeedData(modelBuilder);
    }

    public static void AddSeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IceCreams>().HasData(
            new IceCreams { Id = 1, Name = "Vanilla Delight", Price = 2.99, Image = "vanilla.png" },
            new IceCreams { Id = 2, Name = "Chocolate Heaven", Price = 3.49, Image = "chocolate.png" },
            new IceCreams { Id = 3, Name = "Strawberry Bliss", Price = 3.29, Image = "strawberry.png" },
            new IceCreams { Id = 4, Name = "Minty Fresh", Price = 3.19, Image = "mint.png" },
            new IceCreams { Id = 5, Name = "Cookie Crunch", Price = 3.59, Image = "cookie.png" }
        );

        // Seed IceCreamOptions
        modelBuilder.Entity<IceCreamOption>().HasData(
            new IceCreamOption { IceCreamId = 1, Flavor = "Classic Vanilla", Topping = "Sprinkles" },
            new IceCreamOption { IceCreamId = 1, Flavor = "French Vanilla", Topping = "Caramel Drizzle" },
            new IceCreamOption { IceCreamId = 2, Flavor = "Dark Chocolate", Topping = "Choco Chips" },
            new IceCreamOption { IceCreamId = 2, Flavor = "Milk Chocolate", Topping = "Brownie Bites" },
            new IceCreamOption { IceCreamId = 3, Flavor = "Fresh Strawberry", Topping = "Whipped Cream" },
            new IceCreamOption { IceCreamId = 4, Flavor = "Mint Chocolate", Topping = "Choco Syrup" },
            new IceCreamOption { IceCreamId = 5, Flavor = "Cookies & Cream", Topping = "Crushed Oreos" }
        );
    }
}
