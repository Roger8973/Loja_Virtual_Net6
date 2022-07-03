using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Models;
using GeekShopping.ProductAPI.Repository;
using GeekShopping.ProductAPI.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            IEnumerable<ProductVO> products;
            products = await _repository.FindAll();
            return Ok(products);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {        
            ProductVO product = await _repository.FindById(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            ProductVO product = await _repository.Create(vo);
            return Ok(product);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            ProductVO product = await _repository.Update(vo);
            return Ok(product);
        }

        [Authorize (Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
