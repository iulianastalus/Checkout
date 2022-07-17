namespace Basket.Domain.Models;

public class ShoppingCart
{
    #region Constructor
    public ShoppingCart()
    {

    }

    public ShoppingCart(string customer)
    {
        Customer = customer;
    }
    #endregion

    #region Properties
    public Guid Id { get; set; }
    public string Customer { get; set; }
    public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>(); 
    public decimal TotalNet 
    { 
        get 
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Price;
            }
            return total;
        } 
    }
    public decimal TotalGros
    {
        get
        {
            return PaysVAT ? TotalNet * 1.1m : TotalNet;
        }
    }
    public bool PaysVAT { get; set; }
    #endregion
}