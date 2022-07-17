using System.ComponentModel.DataAnnotations;

namespace Checkout.Migrations.Data.Entities
{
    public class BaseEntity
    {
        /// <summary >
        /// The primary key field
        /// </summary>        
        [Key]
        [Required]
        public virtual int Id { get; set; }
    }
}
