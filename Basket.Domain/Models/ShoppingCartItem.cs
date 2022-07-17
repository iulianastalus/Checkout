using System.ComponentModel.DataAnnotations.Schema;


namespace Basket.Domain.Models
{
    public class ShoppingCartItem
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
