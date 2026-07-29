using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var apiKey = configuration["Gemini:ApiKey"];

if (string.IsNullOrWhiteSpace(apiKey))
{
    Console.WriteLine("API key not found.");
    return;
}

using var http = new HttpClient();

while (true)
{
    Console.Write("You: ");
    var prompt = Console.ReadLine();

    if (string.Equals(prompt, "exit", StringComparison.OrdinalIgnoreCase))
        break;

    var request = new
    {
        contents = new[]
        {
            new
            {
                parts = new[]
                {
                    new { text = prompt }
                }
            }
        }
    };

    var json = JsonSerializer.Serialize(request);

    var response = await http.PostAsync(
        $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent?key={apiKey}",
        new StringContent(json, Encoding.UTF8, "application/json"));

    response.EnsureSuccessStatusCode();

    var responseJson = await response.Content.ReadAsStringAsync();

    using JsonDocument doc = JsonDocument.Parse(responseJson);

    string answer = doc.RootElement
        .GetProperty("candidates")[0]
        .GetProperty("content")
        .GetProperty("parts")[0]
        .GetProperty("text")
        .GetString()!;

    Console.WriteLine($"\nGemini: {answer}\n");
}