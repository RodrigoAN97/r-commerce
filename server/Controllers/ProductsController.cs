using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts(){
            return "this will be a list of products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id){
            return "this will be a product of id " + id;
        }
    }
}