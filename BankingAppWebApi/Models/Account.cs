namespace TFLBank.models
{
    public class Account
    {
        public string Name { get; set;}
        public string Email { get; set;}
        public string AccountNumber{get;set;}

        public double Balance{get;set;}

        public DateTime CreatedOn{get;set;}

    }
}