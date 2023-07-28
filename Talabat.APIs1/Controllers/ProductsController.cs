using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.Core.Repository;
using Talabat.Core.Specification;
using Talabat.Repository.Entites;
using AutoMapper;
using Talabat.APIs1.Dto;
using System.Linq;

namespace Talabat.APIs1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {

        private readonly IMapper _mapper;
        private IGenericRepository<Product> _repository;
        private IGenericRepository<ProductBrand> _repositoryBrand;
        private IGenericRepository<ProductType> _repositoryType;


        public ProductsController(IGenericRepository<Product> repository, IGenericRepository<ProductBrand> repositoryBrand, IGenericRepository<ProductType> repositoryType, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _repositoryBrand = repositoryBrand;
            _repositoryType = repositoryType;
        }

        // GET: api/<controller>  
        [HttpGet]
        public async Task<ActionResult> GetAllSpecAsync([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductWithBrandAndTypeSpecifications( productSpecParams);

            IReadOnlyList<Product> product = await _repository.GetAllSpecAsync(spec);
            var productDtos = _mapper.Map<List<ProductToReturnDtos>>(product);
            return Ok(productDtos);

        }


        // GET api/<controller>/5  
        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdSpecAsync(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecifications(id);
            Product products = await _repository.GetByIdSpecAsync(spec);


            if (products == null)
            {
                return NotFound("The product record couldn't be found.");
            }

            return Ok(products);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            return Ok(await _repositoryBrand.GetAllAsync());
        }

        [HttpGet("Type")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetTypes()
        {
            return Ok(await _repositoryType.GetAllAsync());
        }


    }
}
