namespace TFLCollection.CreateNode
{
    public class Node<Object>
    {
        public Object obj;
        public Node<Object> next;

        public Node(Object obj)
        {
            this.obj = obj;
            this.next = null;
        }
    }
}