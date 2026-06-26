using TFLBank.models;

namespace TFLBank.TransactionManager.operations
{
    public interface IFundTransferOperation
    {
        bool FundTransfer(string fromAccountNumber, string toAccountNumber, double transferAmount);
    }
}