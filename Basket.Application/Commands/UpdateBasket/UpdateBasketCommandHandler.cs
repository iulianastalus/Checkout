using AutoMapper;
using Basket.Domain.Enums;
using Basket.Domain.Interfaces;
using Basket.Domain.Models;
using Checkout.Domain.Exceptions;
using MediatR;

namespace Basket.Application.Commands.UpdateBasket
{
    public class UpdateBasketCommandHandler :IRequestHandler<UpdateBasketCommand,UpdateBasketResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public UpdateBasketCommandHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<UpdateBasketResponse> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            var basketResult = await _basketRepository.GetBasket(request.Guid.ToString());
            if (basketResult == null)
                throw new EntityNotFoundException(nameof(ShoppingCart));

            basketResult.Items.Add(new ShoppingCartItem
            {
                Name = request.Item,
                Price = request.Price
            });
            var basket = await _basketRepository.UpdateBasket(basketResult);
            var result = _mapper.Map<UpdateBasketResponse>(basket);
            result.Message = MessageType.Success;
            return result;
        }
    }
}
