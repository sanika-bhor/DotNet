using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace EcommerceDapper
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        [HttpPost("AddToCart/user/{userid}/product/{productid}/Quantity/{quantity}/")]
        public  IActionResult AddToCart(int userid,int productid,int quantity,string imgurl)
        {
           bool status= _shoppingCartService.AddToCart(userid, productid, quantity,imgurl);
           if(status)
            {
                return Ok("Product add to cart successfully");
            }
            else
            {
                return BadRequest("Something happened");
            }
        }


        [HttpPost("RemoveFromCart/user/{userid}/product/{productid}/Quantity/{quantity}/")]
        public IActionResult RemoveFromCart(int userid, int productid,int quantity)
        {
            bool status = _shoppingCartService.RemoveFromCart(userid, productid, quantity);
            if (status)
            {
                return Ok("Product remove from cart successfully");
            }
            else
            {
                return BadRequest("Something happened");
            }
        }

    }
}