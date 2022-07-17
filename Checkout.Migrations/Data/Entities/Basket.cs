using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Migrations.Data.Entities;
[Table("Baskets")]
public class Basket :BaseEntity
{
    #region Constructor
    public Basket()
    {

    }
    #endregion

    #region Properties    

    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }

    /// <summary >
    /// Customer reference
    /// </summary>
    public virtual Customer Customer { get; set; }

    /// <summary >
    /// A list containing the basket items
    /// </summary> 
    public virtual List<BasketItem> Items { get; set; }
    #endregion
}