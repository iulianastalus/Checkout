using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commands.UpdateBasket
{
    public class UpdateBasketCommand :IRequest<UpdateBasketResponse>
    {
        public Guid Guid { get; set; }
        public string Item { get; set; }
        public decimal Price { get; set; }

        public UpdateBasketCommand(Guid guid, string item, decimal price)
        {
            Guid = guid;
            Item = item;
            Price = price;
        }
    }
}
