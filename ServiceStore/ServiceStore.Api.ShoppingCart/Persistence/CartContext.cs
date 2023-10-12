using Microsoft.EntityFrameworkCore;
using ServiceStore.Api.ShoppingCart.Models;

namespace ServiceStore.Api.ShoppingCart.Persistence;

public class CartContext : DbContext
{
    public CartContext(DbContextOptions<CartContext> options) : base(options) { }
    
    public DbSet<CartSession> CartSessions { get; set; }
    public DbSet<CartSessionDetail> CartSessionDetails { get; set; }
}