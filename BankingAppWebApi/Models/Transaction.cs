namespace TFLBank.models
{
    public class Transaction
    {
        public string AccountNumber { get; set;}
        public string TransactionStatus{get;set;}
        public string StatusMessage{get;set;}
        public DateTime TransactionDate{get;set;}
        public double Amount{get;set;}
        public double CurrentBalance{get;set;}
    }
}