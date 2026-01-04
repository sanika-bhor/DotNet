using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Api.Controllers;
[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    [HttpPost("add")]
    public IActionResult Add(object item)
    {
        return Ok("Item added to cart");
    }
}
