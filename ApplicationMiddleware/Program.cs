using ApplicationMiddleware;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// app.Use( async(context, next)=>{
//     await context.Response.WriteAsync("\nfirst middleware....");
//     await next();
// });

// app.Use( async(context, next)=>{
//     await context.Response.WriteAsync("\nsecond middleware....");
//     await next();
// });
// app.Run(async context=>{
//     await context.Response.WriteAsync("\nLast middleware!");
// });

app.UseWelcomePage();
// app.requstMapping();
// app.firstMiddleWare();
// app.secondMiddleWare();
// app.thirdMiddleWare();
// app.lastMiddleWare();
app.Run();
