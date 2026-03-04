using Microsoft.AspNetCore.Mvc;
using OtpVerificationApp.Helpers;
using OtpVerificationApp.Models;
using OtpVerificationApp.Services;

namespace OtpVerificationApp.Controllers;

[ApiController]
[Route("api/otp")]
public class OtpController : ControllerBase
{
    private readonly OtpService _otpService;
    private readonly SmsService _smsService;

    public OtpController(OtpService otpService, SmsService smsService)
    {
        _otpService = otpService;
        _smsService = smsService;
    }

    [HttpPost("send")]
    public IActionResult SendOtp([FromBody] SendOtpRequest request)
    {
        var otp = OtpGenerator.Generate();
        _otpService.SaveOtp(request.PhoneNumber, otp);
        _smsService.SendOtp(request.PhoneNumber, otp);

        return Ok("OTP sent via SMS");
    }

    [HttpPost("verify")]
    public IActionResult VerifyOtp([FromBody] VerifyOtpRequest request)
    {
        var isValid = _otpService.VerifyOtp(
            request.PhoneNumber,
            request.Otp
        );

        if (!isValid)
            return Unauthorized("Invalid or expired OTP");

        return Ok("OTP verified successfully");
    }
}