using TFLBank.models;

namespace TFLBank.FileManager
{
    public interface ITransactionsRepository
    {
        bool SaveTransactions(List<Transaction> transactionHistory);
        List<Transaction> LoadTransactions();
    }
}