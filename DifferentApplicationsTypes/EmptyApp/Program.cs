// This initializes the application builder and sets up configuration, logging, and other services.
var builder = WebApplication.CreateBuilder(args);
// this builds the application pipeline
var app = builder.Build();


// Define endpoints:
// HTTP request mapping
app.MapGet("/", () => "Hello World!");
app.MapGet("/about",()=>"<h1>About us</h1>");

// This starts the application and listens for incoming HTTP requests.
app.Run();
