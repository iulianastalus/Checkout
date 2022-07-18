using Basket.Domain.Enums;
using Basket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commands.UpdateBasket
{
    public class UpdateBasketResponse
    {
        public string BasketId { get; set; }
        public string Customer { get; set; }
        public bool PaysVAT { get; set; }
        public List<ShoppingCartItem> Items { get; set; }
        public MessageType Message { get; set; }
        public string SuccessMessage
        {
            get
            {
                return Message == MessageType.Success ? "Success" : "Error";
            }
        }
    }
}
