using MediatR;

namespace Basket.Application.Queries.GetBasket
{
    public class GetBasketQuery : IRequest<GetBasketResponse>
    {
        public Guid Id { get; set; }
    }
}
