namespace TFLCollections
{
    public class Node<T>
    {
        public T obj;
        public Node<T> next;

        public Node(T obj)
        {
            this.obj = obj;
            this.next = null;
        }
    }
}