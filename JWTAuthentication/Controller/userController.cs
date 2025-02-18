using JWTAuthentication.Entities;
using JWTAuthentication.Model;
using JWTAuthentication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers // Updated namespace to Controllers
{
    [ApiController]
    [Route("api/[controller]")] // This should NOT be commented out
    public class UserController : ControllerBase // Updated to PascalCase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) // Meaningful parameter name
        {
            _userService = userService;
        }

        [HttpPost("authenticate")] // Use "authenticate" for consistency
        public IActionResult Authentication([FromBody] AuthenticationRequest model) // Added [FromBody]
        {
            var token = _userService.Authenticate(model);

            if (token == null) // Check token, not Response
            {
                return BadRequest(new { message = "Incorrect username or password" });
            }
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsers()
        {
            List<User> users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
