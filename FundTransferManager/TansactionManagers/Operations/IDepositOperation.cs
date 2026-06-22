namespace TFLBank.TransactionManager.operations
{
    public interface IDepositOperation
    {
        bool Deposit(string accountid,double amount);
    }
}