using Microsoft.AspNetCore.Mvc;
using server.Entities;
using Microsoft.EntityFrameworkCore;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(){
            var products = await _context.Products.ToListAsync();
            return products;
        }

        [HttpGet("{id}")]
        public string GetProduct(int id){
            return "this will be a product of id " + id;
        }
    }
}