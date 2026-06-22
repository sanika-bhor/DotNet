namespace TFLBank.NotificationServices
{
    public class EmailService: INotificationService
    {
        public void send(string msg)
        {
            Console.WriteLine("Email: " + msg);
        }
         
    }
}