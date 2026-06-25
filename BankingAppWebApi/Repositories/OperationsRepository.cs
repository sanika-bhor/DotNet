using System.Text.Json;
using TFLBank.models;

namespace TFLBank.FileManager
{
    public class OperationsRepository : IOperationsRepository
    {

        public List<Operation> GetAllOperations()
        {
            string fileName = @"./Data/operations.json";
            string jsonString = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Operation>? operations = JsonSerializer.Deserialize<List<Operation>>(jsonString, options);
            return operations;
        }
        public bool SaveOpeations(List<Operation> accounts)
        {
            bool status = false;
            string fileName = @"./Data/operations.json";
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string jsonString = JsonSerializer.Serialize(accounts, options);
            File.WriteAllText(fileName, jsonString);
            status = true;
            return status;
        }
    }   
}