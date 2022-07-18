using Basket.Application.Commands.UpdateBasket;
using Checkout.Application.Commands.CreateBasket;
using Checkout.Application.Common.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Controllers
{
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IMediator _mediator;

        public BasketController(ILogger<BasketController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateBasketResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        [HttpPost("Baskets")]
        public async Task<IActionResult> CreateBasket([FromBody] CreateBasketCommand createBasketCommand, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(createBasketCommand,cancellationToken);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateBasketResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        [HttpPut("Baskets/{id}/article-line")]
        public async Task<IActionResult> UpdateBasket([FromBody] UpdateBasketCommand updateBasketCommand,Guid id, CancellationToken cancellationToken = default)
        {
            updateBasketCommand.Guid = id;
            var result = await _mediator.Send(updateBasketCommand, cancellationToken);
            return Ok(result);
        }
    }
}