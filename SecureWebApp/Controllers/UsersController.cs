using Microsoft.AspNetCore.Mvc;
using SecureWebApp.Models;
using SecureWebApp.Services;

namespace SecureWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response=_userService.Authenticate(model);

            if (response == null)
            {
                return BadRequest(new {message="Username or password is incorrect"});
            }
            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users=_userService.GetAll();
            return Ok(users);
        }

        
        // [HttpPost]
        // public IActionResult SendMessage()
        // {
        //     MimeMessage message=new MimeMessage();

        //     MailboxAddress from new MailboxAddress("Admin","admin@example.com")
        //     message.To.Add(to);

        //     MessageProcessingHandler.Subject="This is email subject";

        //     BodyBuilder bodyBuider=new BodyBuilder();
        //     bodyBuider.HtmlBody="<h1>Hello Word</h1>";
        //     bodyBuider.TextBody="Hello world!";

        //     message.Body=bodyBuider.ToMessageBody();

        // }
    }
}