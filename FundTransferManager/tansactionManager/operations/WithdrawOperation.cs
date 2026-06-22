namespace FundTransfer.TransactionManager.operations
{
    public interface WithdrawOperation
    {
        bool withdraw(string accountid,double amount);
    }
}