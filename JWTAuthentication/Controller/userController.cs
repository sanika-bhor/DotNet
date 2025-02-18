using JWTAuthentication.Entities;
using JWTAuthentication.Model;
using JWTAuthentication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class userController:ControllerBase
    {
        private readonly IUserService _userService;
         
         public userController(IUserService srv)
         {
            _userService=srv;
         }
         [HttpPost("authenticate")]
         public IActionResult Authentication(AuthenticationRequest model)
        {
            var token=_userService.Authenticate(model);

            if(Response==null)
            {
                return BadRequest(new {message="incorrect username password"});
            }
            return Ok(token);
        }
        [Authorize]
        [HttpGet]
         public IActionResult GetUsers()
         {
            List<User> users=  _userService.GetAllUsers();
            return Ok(users);
         }
    }
}