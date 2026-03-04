using OtpVerificationApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddScoped<OtpService>();
builder.Services.AddScoped<SmsService>();
builder.Services.AddControllers();

var app = builder.Build();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();


