namespace OtpVerificationApp.Helpers;

public static class OtpGenerator
{
    public static string Generate(int length = 6)
    {
        var random = new Random();
        return random.Next(0, (int)Math.Pow(10, length))
                     .ToString($"D{length}");
    }
}