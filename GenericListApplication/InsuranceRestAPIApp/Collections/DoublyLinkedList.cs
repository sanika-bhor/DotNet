
using System.Collections;

namespace TFLCollections
{
    public class TFLDoublyList<T> : IEnumerable<T>
    {
        public DoublyNode<T> head;
        public DoublyNode<T> tail;

        public TFLDoublyList()
        {
            head = null;
            tail = null;
        }
        public void InsertAtFirst(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);
            if (head == null)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                head.Prev = newNode;
                newNode.Next = head;
                head = newNode;
            }
        }

        public void InsertAtLast(T data)
        {
            DoublyNode<T> newNode = new DoublyNode<T>(data);

            if (head == null)
            {
                head = newNode;
                tail = head;
            }
            else
            {
                DoublyNode<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
                newNode.Prev = current;
                tail = newNode;
            }
        }

        // public void InsertAtMiddle(T data)
        // {
        //     DoublyNode<T> newNode = new DoublyNode<T>(data);

        //     DoublyNode<T> current = head;
        //     while (current.Next!=null && current.Next.data<data)
        //     {
        //         current = current.Next;
        //     }
        //     newNode.Next = current.Next;
        //     current.Next.Prev = newNode;
        //     newNode.Prev = current;
        //     current.Next = newNode;
        // }

        public void UpdateAnyWhere(T oldData, T newData)
        {

            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(oldData))
                {
                    current.data = newData;
                    break;
                }
                current = current.Next;
            }

        }

        public void Delete(T data)
        {
            if (head.data.Equals(data))
            {
                if (head.Next == null)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = head.Next;
                }
            }
            else
            {
                DoublyNode<T> current = head;
                while (!current.Next.data.Equals(data))
                {
                    current = current.Next;
                }

                if (current.Next.Next == null)
                {
                    current.Next = null;
                    tail = current;
                }
                else
                {
                    current.Next = current.Next.Next;
                    current.Next.Prev = current;
                }
            }

        }

        public void DisplayFromHead()
        {
            DoublyNode<T> current = head;
            Console.WriteLine("\n\n\nNext Element: ");
            Console.Write("null--->");
            while (current != null)
            {
                Console.Write(current.data + "--->");
                current = current.Next;
            }
            Console.Write("null\n");

        }

        public void DisplayFromTail()
        {
            Console.WriteLine("Prev Element");
            Console.Write("null");
            DoublyNode<T> current = tail;
            while (current != null)
            {
                Console.Write("<---" + current.data);
                current = current.Prev;
            }
            Console.Write("<---null");
        }

        public IEnumerator<T> GetEnumerator()
        {
             DoublyNode<T> current = head;
            while (current != null)
            {
               yield return current.data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

       
    }
}