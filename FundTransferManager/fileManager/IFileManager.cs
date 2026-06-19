using FundTransfer.models;

namespace FundTransfer.FileManager
{
    public interface IFileManager
    {
        List<Account> GetAllAccounts();
        void SaveAllAccounts();

        void saveOpeations();
        List<Operation> GetAllOperations();
    }
}