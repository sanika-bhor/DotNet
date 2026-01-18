using Microsoft.Extensions.Options;

namespace SecureWebApp.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next,IOptions<AppSettings> appSettings)
        {
            _next=next;
            _appSettings=appSettings.Value;
        }


        public async Task Invoke(HttpContext context,IUserService userService)
        {
            
        }
    }
}