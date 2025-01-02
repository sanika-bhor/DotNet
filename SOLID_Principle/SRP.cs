//SRP --> single reponsibility principle
namespace SRP
{
    public interface IServerUtility
    {
         void GetMessage();
         void TranslateMessage();
         void Dispatch();
    }

    public class ServiceUtility:IServerUtility
    {
        void IServerUtility.GetMessage()
        {
            //get message
            Console.WriteLine("getting your message service....");
        }
        void IServerUtility.TranslateMessage()
        {
            //Translating message
            Console.WriteLine("Translating message service......");

        }
        void IServerUtility.Dispatch()
        {
            //disposal of that message
            Console.WriteLine("dispatch message service......");

        }
    }

   public class NotificationUtility:IServerUtility
    {
        void IServerUtility.GetMessage()
        {
            //get message
            Console.WriteLine("getting your message notification....");
        }
        void IServerUtility.TranslateMessage()
        {
            //Translating message
            Console.WriteLine("Translating message notification......");

        }
        void IServerUtility.Dispatch()
        {
            //disposal of that message
            Console.WriteLine("dispatch message notification......");

        }
    }

    public class Server
    {
        IServerUtility utility;

        public Server(IServerUtility utility)
        {
            this.utility=utility;
        }

        public void GetMessageService()
        {
            utility.GetMessage();
        }

        public void DoService()
        {
            utility.TranslateMessage();
        }

        public void DispatchService()
        {
            utility.Dispatch();
        }
    }
} 