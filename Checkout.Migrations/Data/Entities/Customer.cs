using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.Migrations.Data.Entities
{
    [Table("Customers")]
    public class Customer : BaseEntity
    {
        #region Constructor
        public Customer()
        {

        }
        #endregion

        #region Properties
        public string Name { get; set; }

        /// <summary >
        ///  Basket reference
        /// </summary>

        public virtual Basket Basket { get; set; }
        #endregion
    }
}
