using FundTransfer.models;

namespace FundTransfer.FileManager
{
    public interface IFileManager
    {
        List<Account> GetAllAccounts();
        bool SaveAllAccounts(List<Account> accounts);

        bool saveOpeations(List<Operation> operations);
        List<Operation> GetAllOperations();
    }
}