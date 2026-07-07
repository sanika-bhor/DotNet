namespace TFLCollections
{
    public class DoublyNode<T>
    {
        public T data;
        public DoublyNode<T> Prev;
        public DoublyNode<T> Next;
        public DoublyNode(T data)
        {
            this.data = data;
            this.Prev = null;
            this.Next = null;
        }
    }
}