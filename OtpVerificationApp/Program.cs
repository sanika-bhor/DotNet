

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddScoped<OtpService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddControllers();

var app = builder.Build();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();


