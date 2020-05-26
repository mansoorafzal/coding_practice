namespace coding_practice.data_structure
{
    public class Stack<T>
    {   
        private LinkedList<T> _list;

        public Stack()
        {   
            _list = new LinkedList<T>();
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public void Push(T item)
        {
            _list.InsertFirst(item);
        }

        public T Pop()
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

        public void PushAtBottom(T item)
        {
            _list.InsertLast(item);
        }
    }
}
