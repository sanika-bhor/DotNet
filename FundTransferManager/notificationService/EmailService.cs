namespace FundTransfer.NotificationServices
{
    public class EmailService: NotificationService
    {
        public void send(string msg)
        {
            Console.WriteLine("Email: " + msg);
        }
         
    }
}