using System.Collections;
using TFLCollections;

namespace TFLCollections
{
    public class TFLList<T> :IEnumerable<T>
    {
        public Node<T> head;

       public TFLList()
        {
            head = null;
        }

        public void AddNodeEnd(T obj)
        {

            Node<T> node = new Node<T>(obj);
           
           if(head==null)
            {
                head=node;
            }
            else
            {
                Node<T> p = head;
                while (p.next != null)
                {
                    p = p.next;
                }

                p.next = node;
            }
            
        }

        public void AddNodeMiddle(T obj,int loc)
        {
            Node<T> node = new Node<T>(obj);
           
                Node<T> p = head;
                int traverseIndex=1;
                while (traverseIndex != loc-1)
                {
                    p = p.next;
                    traverseIndex++;
                }
                if(p.next==null)
                {
                    AddNodeEnd(obj);
                }
                else
                {
                    node.next= p.next;
                    p.next=node;
                }

            
        }

        public void AddNodeFirst(T obj)
        {
            Node<T> node = new Node<T>(obj);
            node.next = head;
            head = node;
        }

        // public IEnumerable<T> Display()
        // {
        //     Node<T> p = head;
        //     while (p != null)
        //     {
        //         // Console.Write(p.obj.ToString() + "-->");
        //         yield return p.obj;
        //         p = p.next;
        //     }
        // //    yield return null;
        // }

        public void DeleteFromEnd()
        {
            Node<T> current = head;
            while (current.next.next != null)
            {
                current = current.next;
            }
            current.next = null;

        }

        public void DeleteFromFirst()
        {
            head = head.next;

        }

        public void DeleteFromMiddle(T obj)
        {
            Node<T> current = head;
            while (!current.next.obj.Equals(obj))
            {
                current = current.next;
            }
            if(current.next.obj == null)
            {
                DeleteFromEnd();
            }
            else
            {
                current.next = current.next.next;
            }

        }


       public void Delete(T obj)
        {
            if(head.obj.Equals(obj))
            {
                DeleteFromFirst();
            }
            else
            {
                DeleteFromMiddle(obj);
            }
        }


        public void Insert(T obj,int loc)
        {
            if (head==null || loc==1)
            {
                AddNodeFirst(obj);
            }
            else
            {
                AddNodeMiddle(obj,loc);
            }
        }


        public void Update(T oldobj, T newobj)
        {
            Node<T> current = head;
            while (current.obj.Equals(oldobj))
            {
                current = current.next;
            }
            current.obj = newobj;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> p = head;
            while (p != null)
            {
                yield return p.obj;
                p = p.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}