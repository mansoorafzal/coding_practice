namespace coding_practice.data_structure
{
    public class Node<T>
    {
        public Node(T item)
        {
            Item = item;
            Left = null;
            Right = null;
            Next = null;
            Count = 1;
        }

        public T Item { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public Node<T> Next { get; set; }

        public int Count { get; set; }
    }
}
