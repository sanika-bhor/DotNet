using FundTransfer.models;

namespace FundTransfer.TransactionManager.operations
{
    public interface CreateAccountOperation
    {
        bool createAccount(Account account);
    }
}