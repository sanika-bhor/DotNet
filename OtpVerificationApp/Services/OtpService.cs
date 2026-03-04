using Microsoft.Extensions.Caching.Memory;

namespace OtpVerificationApp.Services;

public class OtpService
{
    private readonly IMemoryCache _cache;

    public OtpService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public void SaveOtp(string email, string otp)
    {
        _cache.Set(email, otp, TimeSpan.FromMinutes(5));
    }

    public bool VerifyOtp(string email, string otp)
    {
        return _cache.TryGetValue(email, out string storedOtp)
               && storedOtp == otp;
    }
}