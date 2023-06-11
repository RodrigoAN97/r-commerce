using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Core.Entities;
using server.Core.Interfaces;

namespace server.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository repository;
        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(string sort = "")
        {
            var products = await this.repository.GetProductsAsync(sort);
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(String), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product?>> GetProduct(int id)
        {
            Product? product = await this.repository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await this.repository.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await this.repository.GetProductTypesAsync());
        }
    }
}