using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites;
using Talabat.Core.Repository;
using System.Text.Json;

namespace Talabat.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            database = redis.GetDatabase();

        }
        public async Task<bool> DeleteBasketAsync(string Basketid)
        {
            return await database.KeyDeleteAsync(Basketid);

            
        }


    public async Task<CustomerBasket> GetBasketAsync(string Basketid)
    {
            var basket = await database.StringGetAsync(Basketid);
            if (String.IsNullOrEmpty(basket))
                return null;
            return JsonConvert.DeserializeObject<CustomerBasket>(basket);



    }


    public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {

            var CreateOrUpdatebasket = await database.StringSetAsync(basket.Id,JsonConvert.SerializeObject(basket),TimeSpan.FromDays(30));
            if (CreateOrUpdatebasket == false) return null;

            return await GetBasketAsync(basket.Id); 
            //JsonSerializer.Deserialize<CustomerBasket>(basket.ToString());
        }
    }
}
