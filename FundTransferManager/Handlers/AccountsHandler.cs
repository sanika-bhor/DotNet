using TFLBank.Listener;
using TFLBank.models;

namespace TFLBank.Listener
{
    public class AccountsHandler : IAccountsHandler
    {
        public void OnUnderBalance(Account acct)
        {
            Console.WriteLine("Amount is less than  minimum balance policy");
        }

        public void OnOverBalance(Account acct)
        {
            Console.WriteLine("Amount is greater than  Taxable income policy");
        }
    }
}