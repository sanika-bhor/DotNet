var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//-----------------------------------------------------------------------------------------
// register distributed cache memory for session management
//DistributedMemory Cache
//--it ia a separete cache memory which is reserved for session data.
builder.Services.AddDistributedMemoryCache();
//-----------------------------------------------------------------------------------------
// add sestion 
builder.Services.AddSession(options=>{
    options.IdleTimeout=TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly=true;
    options.Cookie.IsEssential=true;
});

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
//setup session middleware
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
