namespace TFLBank.models
{
    public class Operation
    {
        public string AccountNumber { get; set;}
        public string Status{get;set;}
        public string StatusMessage{get;set;}
        public DateTime OperationON{get;set;}
        public double Amount{get;set;}
        public double CurrentBalance{get;set;}
    }
}