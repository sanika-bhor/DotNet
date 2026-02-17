using ShipmentService;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddHostedService<OrderConsumer>();
var app = builder.Build();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
