// Sets up the application with default configurations such as logging, configuration sources, and dependency injection.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Builds the application pipeline.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Redirects HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Enables serving static files like CSS, JavaScript, images, etc., from the wwwroot folder.
app.UseStaticFiles();

// Enables routing for the application.
app.UseRouting();

// Adds authorization middleware to validate user access 
app.UseAuthorization();

// Maps Razor Pages to endpoints, enabling navigation to .cshtml pages in the Pages folder.
app.MapRazorPages();

// Starts the application and listens for incoming requests.
app.Run();
