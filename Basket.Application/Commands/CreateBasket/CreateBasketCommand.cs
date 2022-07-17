using MediatR;

namespace Checkout.Application.Commands.CreateBasket
{
    public class CreateBasketCommand :IRequest<CreateBasketResponse>
    {
        public string Customer { get; set; }
        public bool PaysVAT { get; set; }
    }
}
