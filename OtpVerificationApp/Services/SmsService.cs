using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace OtpVerificationApp.Services;

public class SmsService
{
    private const string accountSid = "ACxxxxxxxxxxxxxxxxxxxx";
    private const string authToken = "xxxxxxxxxxxxxxxxxxxx";
    private const string fromNumber = "+13045015269";

    public SmsService()
    {
        TwilioClient.Init(accountSid, authToken);
    }

    public void SendOtp(string phoneNumber, string otp)
    {
        MessageResource.Create(
            body: $"Your OTP is {otp}",
            from: new Twilio.Types.PhoneNumber(fromNumber),
            to: new Twilio.Types.PhoneNumber(phoneNumber)
        );
    }
}