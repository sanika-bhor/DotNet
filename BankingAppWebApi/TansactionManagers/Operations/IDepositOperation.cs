namespace TFLBank.TransactionManager.operations
{
    public interface IDepositOperation
    {
        bool Deposit(string accountNumber, double depositeAmount);
    }
}