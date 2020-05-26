namespace coding_challenges
{
    public class PriorityQueue<T>
    {
        private BinaryHeap<T> _binaryHeap;

        public PriorityQueue(int capacity, Constant.Priority priority = Constant.Priority.Maximum)
        {
            if (priority == Constant.Priority.Maximum)
            {
                _binaryHeap = new MaxBinaryHeap<T>(capacity);
            }
            else if (priority == Constant.Priority.Minimum)
            {
                _binaryHeap = new MinBinaryHeap<T>(capacity);
            }
            else
            {
                _binaryHeap = new BinaryHeap<T>(capacity);
            }
        }

        public int Count
        {
            get { return _binaryHeap.Size; }
        }

        public void Enqueue(T item)
        {
            _binaryHeap.Insert(item);
        }

        public T Dequeue()
        {
            T item = default(T);

            if (Count > 0)
            {
                item = _binaryHeap.Remove();
            }

            return item;
        }

        public T Peek()
        {
            T item = default(T);

            if (Count > 0)
            {
                item = _binaryHeap[0];
            }

            return item;
        }

        public void PrintRegular()
        {
            _binaryHeap.GenerateAndPrintTraversal();
        }
    }
}
