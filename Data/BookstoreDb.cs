using Microsoft.EntityFrameworkCore;
using comp4513_bookstore.Models;

namespace comp4513_bookstore.Data;

public class BookstoreDb(DbContextOptions<BookstoreDb> options) : DbContext(options)
{
    public DbSet<Book> Books {get; set;}
    public DbSet<Order> Orders {get; set;}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Order>()
            .OwnsMany(e => e.OrderItems);
    }
}

