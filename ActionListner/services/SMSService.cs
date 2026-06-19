namespace ActionListener.Services
{
    public class SMSService : NotificationService
    {
        public void send(string msg)
        {
            Console.WriteLine("SMS: " + msg);
        }

    }
}