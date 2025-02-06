using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Model;
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


        [HttpPost("api/addProduct")]
        public IActionResult Insert([FromBody] Product p)
        {
            try
            {
                bool status=_srv.Insert(p);
                if(status)
                {
                    return Ok("product inserted");
                }
                return BadRequest();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }



        [HttpPut("api/updateProduct")]
        public IActionResult Update([FromBody] Product p)
        {
            try
            {
                bool status = _srv.Update(p);
                if (status)
                {
                    return Ok("product updated");
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("api/deleteProduct/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool status=_srv.Delete(id);
                if(status)
                {
                    return Ok("product deleted ");
                }
                return BadRequest();
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }


   
}
