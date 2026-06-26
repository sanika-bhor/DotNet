using TFLBank.models;


namespace TFLBank.TransactionManager.operations
{
    public interface ICalculateInterestOperation
    {
        double CalculateInterest(string accountNumber);
    }
}