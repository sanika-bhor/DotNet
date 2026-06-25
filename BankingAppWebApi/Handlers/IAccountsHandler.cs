using TFLBank.models;

namespace TFLBank.Listener
{
    public interface IAccountsHandler
    {
        void OnUnderBalance(Account  acct);
        void OnOverBalance(Account acct);
    }
}