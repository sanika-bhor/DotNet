using System.Text.Json;
namespace backend.Services;
public class JsonLogger
{
    private static readonly string filePath = "emailLogs.json";

    public static void Log(EmailLog log)
    {
        List<EmailLog> logs = new List<EmailLog>();

        if (File.Exists(filePath))
        {
            string existingJson = File.ReadAllText(filePath);
            logs = JsonSerializer.Deserialize<List<EmailLog>>(existingJson) ?? new List<EmailLog>();
        }

        logs.Add(log);

        string newJson = JsonSerializer.Serialize(logs, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, newJson);
    }
}