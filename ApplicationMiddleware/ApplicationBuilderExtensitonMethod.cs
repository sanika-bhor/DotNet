using Microsoft.AspNetCore.Builder;
namespace ApplicationMiddleware;
public static class ApplicationBuilderExtensionMethod
{

    public static void requstMapping(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
         {
            if(context.Request.Path=="/hello")
            {
             await context.Response.WriteAsync("Hello World....");
            }
            else
            {
                await context.Response.WriteAsync("processing...");
            }
            await next();

         });
    }
    public static void firstMiddleWare(this IApplicationBuilder app)
    {
       app.Use( async (context, next) =>
        {
            await context.Response.WriteAsync("\nfirst middleware....");
            await next();
        });
    }

    public static void secondMiddleWare(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
         {
             await context.Response.WriteAsync("\nsecond middleware....");
             await next();
         });
    }

    public static void thirdMiddleWare(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
         {
             await context.Response.WriteAsync("\nThird middleware....");
             await next();
         });
    }

    public static void lastMiddleWare(this IApplicationBuilder app)
    {
        app.Run(async context =>
         {
             await context.Response.WriteAsync("\nlast middleware! ");
         });
    }
}