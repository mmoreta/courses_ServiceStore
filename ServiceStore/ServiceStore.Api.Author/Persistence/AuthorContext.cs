using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.Author.Models;

namespace ServiceStore.Api.Author.Persistence;

public class AuthorContext : DbContext
{
    public AuthorContext(DbContextOptions<AuthorContext> options) : base(options){ }
    
    public DbSet<AuthorBook> AuthorBooks { get; set; }
    public DbSet<AcademicDegree> AcademicDegrees { get; set; }
}