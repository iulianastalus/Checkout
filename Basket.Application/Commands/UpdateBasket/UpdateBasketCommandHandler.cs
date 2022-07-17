using AutoMapper;
using Basket.Domain.Interfaces;
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

        Task<UpdateBasketResponse> IRequestHandler<UpdateBasketCommand, UpdateBasketResponse>.Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
