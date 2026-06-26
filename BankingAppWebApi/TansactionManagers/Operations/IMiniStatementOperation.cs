using TFLBank.models;

namespace TFLBank.TransactionManager.operations
{
    public interface IMiniStatement
    {
        List<Transaction> GetMiniStatement(string accountNumber);
    }
}