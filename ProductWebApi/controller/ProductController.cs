using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Service;

namespace ProductWebApi.Contoller
{
    [ApiController]
    public class ProductController:ControllerBase
    {
        IProductService _srv;

        public ProductController(IProductService srv)
        {
            this._srv=_srv;
        }

        [HttpGet]
        
        [Route("/api/product")]
        public IActionResult GetProduct()
        {
            try{
                 var products=_srv.GetProducts();
                 if(products==null)
                 {
                    return NotFound();
                 }
                 else
                 {
                    return Ok(products);
                 }
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}