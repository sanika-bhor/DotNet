using TFLBank.models;

namespace TFLBank.TransactionManager.operations
{
    public interface ICreateAccountOperation
    {
        bool CreateAccount(Account account);
    }
}