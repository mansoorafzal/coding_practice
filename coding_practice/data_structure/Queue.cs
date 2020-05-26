namespace coding_challenges
{
    public class Queue<T>
    {   
        private LinkedList<T> _list;

        public Queue()
        {
            _list = new LinkedList<T>();
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public void Enqueue(T item)
        {
            _list.InsertLast(item);
        }

        public T Dequeue()
        {
            T item = default(T);

            if(_list.Count > 0)
            {
                item = _list.GetFirst();
                _list.RemoveFirst();
            }

            return item;
        }

        public T Peek()
        {
            T item = default(T);

            if (_list.Count > 0)
            {
                item = _list.GetFirst();
            }

            return item;
        }

        public void PrintRegular()
        {
            _list.PrintRegular();
        }
    }
}
