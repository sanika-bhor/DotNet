namespace ActionListener.Listener
{
    public interface AccountListener
    {
        void onUnderBalance(double balance);
        void onOverBalance(double balance);
    }
}