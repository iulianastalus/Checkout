using Basket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Queries.GetBasket
{
    public class GetBasketResponse
    {
        public string Id { get; set; }
        public string Customer { get; set; }
        public List<ShoppingCartItem> Items { get;set;}
        public decimal TotalNet { get; set; }
        public decimal TotalGross { get; set; }
        public bool PaysVAT { get; set; }
    }
}
