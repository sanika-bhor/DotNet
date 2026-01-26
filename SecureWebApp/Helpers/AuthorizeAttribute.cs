using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SecureWebApp.Entities;

public class AuthorizeAttribute: Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user=(User)context.HttpContext.Items["User"];
        if(user==null)
        {
            context.Result=new JsonResult(new {message="unauthorized"}){StatusCode=StatusCodes.Status401Unauthorized };
        }
    }
}