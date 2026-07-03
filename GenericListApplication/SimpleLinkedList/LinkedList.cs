using System.Collections;
using TFLCollection.CreateNode;

namespace TFLCollection.List
{
    public class TFLList<Object> :IEnumerable<Object>
    {
        public Node<Object> head = null;


        public void AddNodeEnd(Object data)
        {
            Node<Object> node = new Node<Object>(data);
           
                Node<Object> p = head;
                while (p.next != null)
                {
                    p = p.next;
                }

                p.next = node;

            
        }

        public void AddNodeMiddle(Object data,int loc)
        {
            Node<Object> node = new Node<Object>(data);
           
                Node<Object> p = head;
                int traverseIndex=1;
                while (traverseIndex != loc-1)
                {
                    p = p.next;
                    traverseIndex++;
                }
                if(p.next==null)
                {
                    AddNodeEnd(data);
                }
                else
                {
                    node.next= p.next;
                    p.next=node;
                }

            
        }

        public void AddNodeFirst(Object data)
        {
            Node<Object> node = new Node<Object>(data);
            node.next = head;
            head = node;
        }

        // public IEnumerable<Object> Display()
        // {
        //     Node<Object> p = head;
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
            Node<Object> current = head;
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

        public void DeleteFromMiddle(Object data)
        {
            Node<Object> current = head;
            while (!current.next.obj.Equals(data))
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


       public void Delete(Object data)
        {
            if(head.obj.Equals(data))
            {
                DeleteFromFirst();
            }
            else
            {
                DeleteFromMiddle(data);
            }
        }


        public void Insert(Object data,int loc)
        {
            if (head==null || loc==1)
            {
                AddNodeFirst(data);
            }
            else
            {
                AddNodeMiddle(data,loc);
            }
        }


        public void Update(Object olddata, Object newdata)
        {
            Node<Object> current = head;
            while (current.obj.Equals(olddata))
            {
                current = current.next;
            }
            current.obj = newdata;
        }

        public IEnumerator<Object> GetEnumerator()
        {
            Node<Object> p = head;
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