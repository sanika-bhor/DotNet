namespace TFLBank.TransactionManager.operations
{
    public interface IWithdrawOperation
    {
        bool Withdraw(string accountNumber, double withdrawAmount);
    }
}