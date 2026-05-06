using Microsoft.AspNetCore.Mvc;
using backend.EmailNotificationManager;
using backend.Helpers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IPasswordService _passwordService;
    private readonly INotificationManager _emailService;

    public AuthController(IPasswordService passwordService, INotificationManager emailService)
    {
        _passwordService = passwordService;
        _emailService = emailService;
    }

    [HttpPost("send-password")]
    public async Task<IActionResult> SendPassword(PasswordRequest request)
    {
        var password = _passwordService.GeneratePassword(request.Email);
        try{
                await _emailService.SendMessageAsync(
            request.Email,
            "password verification",
            password
        );

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return Ok(new { password = password });
    }

    [HttpPost("verify-password")]
    public IActionResult VerifyPassword(PasswordVerifyRequest request)
    {
        var result = _passwordService.VerifyPassword(request.Email, request.Password);

        if (!result)
            return BadRequest("Invalid or Expired Password");

        return Ok("password Verified Successfully");
    }
}
