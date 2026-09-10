using EcommerceDapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IShoppingCartService,ShoppingCartService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.UseHttpsRedirection();


app.Run();

