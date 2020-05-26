using System;

namespace coding_challenges
{
    public class BinaryHeap<T>
    {
        protected T[] _array;

        public BinaryHeap()
        {
            _array = new T[0];
            Size = 0;
        }

        public BinaryHeap(int capacity)
        {
            _array = new T[capacity];
            Size = 0;
        }

        public int Size { get; protected set; }

        public T this[int index]
        {
            get
            {
                T item = default(T);

                if (index < Size)
                {
                    item = _array[index];
                }

                return item;
            }
        }
        public virtual void Insert(T item)
        {
            
        }

        protected virtual void HeapifyBottomToTop(int index)
        {
            
        }

        public virtual T Remove()
        {
            return default(T);
        }

        protected virtual void HeapifyTopToBottom(int index)
        {
            
        }

        public void GenerateAndPrintTraversal(Constant.TraversalType traversalType = Constant.TraversalType.LevelOrder)
        {
            if (traversalType == Constant.TraversalType.LevelOrder)
            {
                LevelOrder();
            }
        }

        private void LevelOrder()
        {
            string traversal = string.Empty;

            for (int i = 0; i < Size; i++)
            {
                traversal += _array[i].ToString() + " - ";
            }

            Console.WriteLine(traversal);
        }
    }
}
