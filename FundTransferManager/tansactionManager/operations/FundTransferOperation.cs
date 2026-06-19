using FundTransfer.models;

namespace FundTransfer.TransactionManager.operations
{
    public interface FundTransferOperation
    {
        void tranferFund(Account fromAccount, Account toAccount, double amount);
    }
}