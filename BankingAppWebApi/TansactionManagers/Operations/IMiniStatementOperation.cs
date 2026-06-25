using TFLBank.models;

namespace TFLBank.TransactionManager.operations
{
    public interface IMiniStatement
    {
        List<Operation> GetMiniStatement(string accountId);
    }
}