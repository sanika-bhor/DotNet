namespace FundTransfer.TransactionManager.operations
{
    public interface WithdrawOperation
    {
        void withdraw(string accountid,double amount);
    }
}