using TFLBank.models;

namespace TFLBank.TransactionManager.operations
{
    public interface IFundTransferOperation
    {
        bool FundTransfer(string fromAccount, string toAccount, double amount);
    }
}