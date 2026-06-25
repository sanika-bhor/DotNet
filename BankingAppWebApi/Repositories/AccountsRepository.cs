using System.Text.Json;
using TFLBank.models;

namespace TFLBank.FileManager
{
    public class AccountsRepository: IAccountsRepository
    {
        public List<Account> GetAllAccounts()
        {
            string fileName = @"./Data/accounts.json";
            string jsonString = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Account>? accounts = JsonSerializer.Deserialize<List<Account>>(jsonString, options);
            return accounts;
        }

        public bool SaveAllAccounts(List<Account> accounts)
        {
            bool status = false;
            string fileName = @"./Data/accounts.json";
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string jsonString = JsonSerializer.Serialize(accounts, options);
            File.WriteAllText(fileName, jsonString);
            status = true;
            return status; 
        }
    }
}