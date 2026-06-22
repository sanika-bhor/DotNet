namespace TFLBank.NotificationServices
{
    public class SMSService : INotificationService
    {
        public void send(string msg)
        {
            Console.WriteLine("SMS: " + msg);
        }

    }
}