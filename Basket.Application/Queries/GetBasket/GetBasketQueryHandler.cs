using AutoMapper;
using Basket.Domain.Interfaces;
using Basket.Domain.Models;
using Checkout.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Queries.GetBasket
{
    public class GetBasketQueryHandler : IRequestHandler<GetBasketQuery,GetBasketResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public GetBasketQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<GetBasketResponse> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var response = await _basketRepository.GetBasket(request.Id.ToString());
            if(response == null)
            {
                throw  new EntityNotFoundException(nameof(ShoppingCart));
            }
            return _mapper.Map<GetBasketResponse>(response);
        }
    }
}
