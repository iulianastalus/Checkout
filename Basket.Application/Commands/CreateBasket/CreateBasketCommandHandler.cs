using AutoMapper;
using Basket.Domain.Enums;
using Basket.Domain.Interfaces;
using Basket.Domain.Models;
using Checkout.Domain.Exceptions;
using MediatR;

namespace Checkout.Application.Commands.CreateBasket
{
    public class CreateBasketCommandHandler  : IRequestHandler<CreateBasketCommand, CreateBasketResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public CreateBasketCommandHandler(IBasketRepository basketRepository,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<CreateBasketResponse> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = _mapper.Map<ShoppingCart>(request);
            var basketResult = await _basketRepository.UpdateBasket(basket);
            if(basketResult == null)
                throw new EntityNotFoundException(nameof(ShoppingCart));           
            var result = _mapper.Map<CreateBasketResponse>(basketResult);
            result.Message = MessageType.Success;
            return result;
        }
    }
}
