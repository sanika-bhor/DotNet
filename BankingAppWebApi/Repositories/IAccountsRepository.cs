using TFLBank.models;

namespace TFLBank.FileManager
{
    public interface IAccountsRepository
    {
        List<Account> GetAllAccounts();
        bool SaveAllAccounts(List<Account> accounts);

           }
}