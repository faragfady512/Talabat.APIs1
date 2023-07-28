using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;
using Talabat.Core.Entites;
using Talabat.Core.Repository;

namespace Talabat.APIs1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket?? new CustomerBasket(id));
        
        }

        [HttpPost]

        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
        {
            var UpdatedOrDeleted = await _basketRepository.UpdateBasketAsync(basket);
            return Ok(UpdatedOrDeleted);
        }

        [HttpDelete]

        public async Task<ActionResult<CustomerBasket>> DeleteBasket(string id)
        {
            var DeletedBasket = await _basketRepository.DeleteBasketAsync(id);

            return Ok(DeletedBasket);
        
        
        }




    }
}
