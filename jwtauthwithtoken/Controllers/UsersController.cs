using JwtDemo.Middleware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpGet("public")]
        public IActionResult PublicApi()
        { return Ok(new { success = true, message = "Public API"}); }

        [Authorize]
        [UserAuthorizationMiddleware]
        [HttpGet("{userId}")]
        public IActionResult PrivateApi(int userId)
        {   
            var tokenUserId =User.FindFirst("userId")?.Value;
            var result= new {success = true,message = "Protected API Accessed",
                             tokenUserId = tokenUserId,requestedUserId = userId};
            return Ok(result);
        }
    }
}