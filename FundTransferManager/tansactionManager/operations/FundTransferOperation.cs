using FundTransfer.models;

namespace FundTransfer.TransactionManager.operations
{
    public interface FundTransferOperation
    {
        bool tranferFund(string fromAccount, string toAccount, double amount);
    }
}