using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Book.Models;

namespace ServiceStore.Api.Book.Persistence;

public class BookContext : DbContext
{
    public BookContext(DbContextOptions<BookContext> options) : base(options) { }
    
    public DbSet<BookLibrary> BookLibraries { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookLibrary>()
            .HasKey(b => b.BookId);

        base.OnModelCreating(modelBuilder);
    }
}