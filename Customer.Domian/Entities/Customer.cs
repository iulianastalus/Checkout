using Customer.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.Domain.Entities;

[Table("Customers")]
public class Customer :BaseEntity
{
    #region Constructor
    public Customer()
    {

    }
    #endregion

    #region Properties
    public string Name { get; set; }
    #endregion
}
