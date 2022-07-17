using System.ComponentModel.DataAnnotations.Schema;


namespace Checkout.Migrations.Data.Entities;

[Table("ItemBasket")]
public class BasketItem :BaseEntity
{
    public double Price { get; set; }
    public virtual Item Item { get; set; }
}
