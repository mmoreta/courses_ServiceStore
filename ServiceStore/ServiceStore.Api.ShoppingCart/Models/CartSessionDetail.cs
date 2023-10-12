namespace ServiceStore.Api.ShoppingCart.Models;

public class CartSessionDetail
{
    public int CartSessionDetailId { get; set; }
    public DateTime CreateDate { get; set; }
    public string SelectedBook { get; set; }
    
    public int CartSessionId { get; set; }
    public CartSession CartSession { get; set; }
}