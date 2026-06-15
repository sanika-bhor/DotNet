using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace JwtDemo.Middleware
{
    public class UserAuthorizationMiddleware : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userIdClaim = context.HttpContext.User.FindFirst("userId");
            if (userIdClaim == null)
            {
                context.Result = new UnauthorizedObjectResult(new
                {
                    success = false,
                    message = "User ID not found in token"
                });
                return;
            }

            int tokenUserId = Convert.ToInt32(userIdClaim.Value);
            if (context.ActionArguments.ContainsKey("userId"))
            {
                int requestUserId =Convert.ToInt32(context.ActionArguments["userId"]);
                if (tokenUserId != requestUserId)
                {
                    context.Result = new ObjectResult(new
                    {
                        success = false,
                        message = "Unauthorized access"
                    })
                    {
                        StatusCode = 403
                    };
                    return;
                }
            }
            base.OnActionExecuting(context);
        }
    }
}





