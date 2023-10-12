namespace ServiceStore.Api.ShoppingCart.Models;

public class CartSession
{
    public int CartSessionId { get; set; }
    public DateTime? CreateDate { get; set; }
    
    public ICollection<CartSessionDetail> ListOfDetails { get; set; }
}