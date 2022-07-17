using Basket.Domain.Enums;

namespace Checkout.Application.Commands.CreateBasket
{
    public class CreateBasketResponse
    {
        public string Customer { get; set; }
        public bool PaysVAT { get; set; }
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
