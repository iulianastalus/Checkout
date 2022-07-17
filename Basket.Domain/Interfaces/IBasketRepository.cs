

using Basket.Domain.Models;

namespace Basket.Domain.Interfaces
{
    public  interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string id);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string id);
    }
}
