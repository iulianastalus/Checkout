using Basket.Domain.Interfaces;
using Basket.Domain.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;
        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache ?? throw new ArgumentNullException(nameof(redisCache));
        }

        public async Task DeleteBasket(string id)
        {
            await _redisCache.RemoveAsync(id);
        }

        public async Task<ShoppingCart> GetBasket(string id)
        {
           var basket = await _redisCache.GetStringAsync(id);
            if (string.IsNullOrEmpty(basket))
                return null;

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            basket.Id = Guid.NewGuid();
            var strBasket = JsonConvert.SerializeObject(basket);            
            await _redisCache.SetStringAsync(basket.Id.ToString(),strBasket);

            return await GetBasket(basket.Id.ToString());
        }
    }
}
