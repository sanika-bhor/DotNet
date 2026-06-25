namespace TFLBank.TransactionManager.operations
{
    public interface IWithdrawOperation
    {
        bool Withdraw(string accountid,double amount);
    }
}