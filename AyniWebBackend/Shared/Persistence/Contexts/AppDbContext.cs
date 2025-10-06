using AyniWebBackend.Ayni.Domain.Models;
using AyniWebBackend.Security.Domain.Models;
using AyniWebBackend.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AyniWebBackend.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    

    public DbSet<User> Users { get; set; }

    public DbSet<Profit> Profits { get; set; }


    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

    
    public DbSet<Crop> Crops { get; set; }


    
    public DbSet<Cost> Costs { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
       base.OnModelCreating(builder);
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p=>p.Email).IsRequired().HasMaxLength(50);
        builder.Entity<User>().Property(p => p.Role).IsRequired();

        
        //Relationships
        builder.Entity<User>()
            .HasMany(p => p.Crops)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        builder.Entity<User>()
            .HasMany(p => p.Costs)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        builder.Entity<User>()
            .HasMany(p => p.Profits)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        
        builder.Entity<User>()
            .HasMany(p => p.Orders )
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId);
        builder.Entity<Product>()
            .HasMany(p=>p.Orders)
            .WithOne(p=>p.Product)
            .HasForeignKey(p=>p.ProductId);
        
        
        builder.Entity<Crop>().ToTable("Crops");
        builder.Entity<Crop>().HasKey(p => p.Id);
        builder.Entity<Crop>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Crop>().Property(p => p.Name).IsRequired();
        builder.Entity<Crop>().Property(p => p.Description);
        builder.Entity<Crop>().Property(p=>p.Distance).IsRequired();
        builder.Entity<Crop>().Property(p=>p.Depth).IsRequired();
        builder.Entity<Crop>().Property(p=>p.Weather).IsRequired();
        builder.Entity<Crop>().Property(p=>p.GroundType).IsRequired();
        builder.Entity<Crop>().Property(p=>p.Season).IsRequired();
        builder.Entity<Crop>().Property(p => p.ImageUrl).IsRequired();
        

        builder.Entity<Cost>().ToTable("Costs");
        builder.Entity<Cost>().HasKey(p => p.Id);
        builder.Entity<Cost>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Cost>().Property(p => p.Name).IsRequired();
        builder.Entity<Cost>().Property(p => p.Description);
        builder.Entity<Cost>().Property(p => p.Amount).IsRequired();

        builder.Entity<Profit>().ToTable("Profits");
        builder.Entity<Profit>().HasKey(p => p.Id);
        builder.Entity<Profit>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profit>().Property(p => p.NameP).IsRequired();
        builder.Entity<Profit>().Property(p => p.DescriptionP);
        builder.Entity<Profit>().Property(p => p.AmountP).IsRequired();

        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired();
        builder.Entity<Product>().Property(p => p.Description);
        builder.Entity<Product>().Property(p => p.UnitPrice);
        builder.Entity<Product>().Property(p => p.Quantity);
        builder.Entity<Product>().Property(p => p.ImageUrl).IsRequired();

        builder.Entity<Order>().ToTable("Orders");
        builder.Entity<Order>().Property(p => p.Id);
        builder.Entity<Order>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(p => p.Description).HasMaxLength(120);
        builder.Entity<Order>().Property(p => p.Status).HasMaxLength(50);
        builder.Entity<Order>().Property(p => p.OrderedDate).IsRequired();
        builder.Entity<Order>().Property(p => p.TotalPrice).IsRequired();
        builder.Entity<Order>().Property(p => p.PaymentMethod).IsRequired().HasMaxLength(50);


        builder.UseSnakeCaseNamingConvention();
    }
}