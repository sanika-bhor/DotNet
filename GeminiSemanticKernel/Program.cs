using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.Google;

var builder = WebApplication.CreateBuilder(args);

// Load User Secrets
builder.Configuration.AddUserSecrets<Program>();

// Add MVC services
builder.Services.AddControllersWithViews();

// Register ChatService
builder.Services.AddScoped<ChatService>();

// Register Kernel
builder.Services.AddSingleton<Kernel>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();

    string? model = configuration["Gemini:Model"];
    string? apiKey = configuration["Gemini:ApiKey"];

    if (string.IsNullOrWhiteSpace(model))
        throw new Exception("Gemini model is missing from appsettings.json");

    if (string.IsNullOrWhiteSpace(apiKey))
        throw new Exception("Gemini API Key is missing from User Secrets.");

    var kernelBuilder = Kernel.CreateBuilder();

    kernelBuilder.AddGoogleAIGeminiChatCompletion(
        modelId: model,
        apiKey: apiKey
    );

    return kernelBuilder.Build();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Chat}/{action=Index}/{id?}");

app.Run();