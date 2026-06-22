namespace FundTransfer.TransactionManager.operations
{
    public interface DepositeOperation
    {
        bool deposite(string accountid,double amount);
    }
}