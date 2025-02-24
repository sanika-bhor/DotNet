using JWTAuthentication.Entities;
using JWTAuthentication.Services;
using Microsoft.AspNetCore.Mvc;

namespace UsersController.UsersController{
    [ApiController]
    [Route("Controller")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try{
                List<User> users=_userService.GetAll();
                if(users==null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch(Exception)
            return Ok(_userService.GetAll());
        }
    }
}