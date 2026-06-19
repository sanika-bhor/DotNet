namespace ActionListener.Listener
{
    public interface IActionListener
    {
        void onUnderBalance(double balance);
        void onOverBalance(double balance);
    }
}