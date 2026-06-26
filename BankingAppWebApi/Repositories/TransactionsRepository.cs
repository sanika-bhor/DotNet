using System.Text.Json;

using TFLBank.models;

namespace TFLBank.FileManager
{
    public class TransactionsRepository : ITransactionsRepository
    {

        string fileName = @"./Data/transactions.json";
        public List<Transaction> LoadTransactions()
        {
            string jsonString = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Transaction>? transactionHistory = JsonSerializer.Deserialize<List<Transaction>>(jsonString, options);
            return transactionHistory;
        }

        public bool SaveTransactions(List<Transaction> transactionHistory)
        {
            bool status = false;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string jsonString = JsonSerializer.Serialize(transactionHistory, options);
            File.WriteAllText(fileName, jsonString);
            status = true;
            return status;
        }

    }   
}