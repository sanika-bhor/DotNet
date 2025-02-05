using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Service;

namespace ProductWebApi.Controller
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _srv;

        public ProductController(IProductService srv)
        {
            this._srv = srv;
        }

        [HttpGet]
    [Route("api/products")]

        public IActionResult GetProduct()
        {
            try
            {
                var products = _srv.GetProducts();
                if (products == null)
                {
                    return NotFound("No products found.");
                }
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
