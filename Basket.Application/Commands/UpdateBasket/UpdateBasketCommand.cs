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
        public string Item { get; set; }
        public decimal Price { get; set; }
    }
}
