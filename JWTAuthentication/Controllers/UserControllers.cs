using JWTAuthentication.Entities;
using JWTAuthentication.Model;
using JWTAuthentication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class UserControllers : ControllerBase 
    {
        private readonly IUserService _userService;

        public UserControllers(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authentication([FromBody] AuthenticationRequest model) 
        {
            var token = _userService.Authenticate(model);

            if (token == null) 
            {
                return BadRequest(new { message = "Incorrect username or password" });
            }
            return Ok( token );
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
