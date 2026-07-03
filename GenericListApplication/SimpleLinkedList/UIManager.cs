
using TFLCollection.Model;

namespace TFLCollection.UIManager
{
    public class UIManager
    {
        public void ShowMenu()
        {
            Console.WriteLine("\n\n\n*******Menu**********");
            Console.WriteLine("1.Insert LinkedList");
            Console.WriteLine("2.Update Node");
            Console.WriteLine("3.Delete Node");
            Console.WriteLine("4.Display Linked List");
            Console.WriteLine("5.Exit");
        }

        public Person AcceptData()
        {
            Person person= new Person(1,"sanika",21);
            return person;
            // Console.WriteLine("enter Id: ");
            // return int.Parse(Console.ReadLine());
        }

        public int AcceptChoice()
        {
            Console.WriteLine("enter your choice: ");
            return int.Parse(Console.ReadLine());
        }

        public int AcceptLocation()
        {
            Console.WriteLine("enter where to insert data: ");
            return int.Parse(Console.ReadLine());
        }

        public void ExitApplication()
        {
            Console.WriteLine("Thank you ");
        }
    }
}