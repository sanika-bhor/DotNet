var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "GreenHouseDetails",
    pattern: "farm/{farmname}/greenhouse/{farmno}",
    defaults: new{Controller= "Farm", Action= "getGreenHouseDetails" }
);

app.MapControllerRoute(
    name: "CropDetails",
    pattern: "farm/{farmname}/greenhouse/{farmno}/crop/{cropid}",
    defaults: new { Controller = "Farm", Action = "getCropDetails" }
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
