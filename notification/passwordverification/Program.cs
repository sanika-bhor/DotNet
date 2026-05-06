using backend.EmailNotificationManager;
using backend.Helpers;
using backend.Settings;
var builder = WebApplication.CreateBuilder(args);

const string CorsPolicyName = "Frontend8081";

builder.Services.AddMemoryCache();
builder.Services.Configure<EmailSettings>(
    builder.Configuration.GetSection("EmailService"));
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<INotificationManager, EmailNotificationManager>();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicyName, policy =>
    {
        policy
            .WithOrigins("http://localhost:8081")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(CorsPolicyName);
app.MapControllers();


app.Run();

