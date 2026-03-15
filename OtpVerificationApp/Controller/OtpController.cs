using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly OtpService _otpService;
    private readonly EmailService _emailService;

    public AuthController(OtpService otpService, EmailService emailService)
    {
        _otpService = otpService;
        _emailService = emailService;
    }

    [HttpPost("send-otp")]
    public IActionResult SendOtp(OtpRequest request)
    {
        var otp = _otpService.GenerateOtp(request.Email);
        _emailService.SendEmail(request.Email, otp);

        return Ok(new { message = "OTP sent successfully" });
    }

    [HttpPost("verify-otp")]
    public IActionResult VerifyOtp(OtpVerifyRequest request)
    {
        var result = _otpService.VerifyOtp(request.Email, request.Otp);

        if (!result)
            return BadRequest("Invalid or Expired OTP");

        return Ok("OTP Verified Successfully");
    }
}