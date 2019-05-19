using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Get(string id)
        {
            ProductDto result = _productsService.GetById(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("Product not found");
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] NewProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<string> Delete(string id)
        {
            string result = _productsService.Delete(id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("Product not found");
        }

        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Put(string id, [FromBody] NewProductDto product)
        {
            ProductDto result = _productsService.EditProduct(id, product);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound("Product not found");
        }
    }
}
