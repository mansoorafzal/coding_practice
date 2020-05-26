using coding_practice.helper;
using System;

namespace coding_practice.data_structure
{
    public class MaxBinaryHeap<T> : BinaryHeap<T>
    {
        public MaxBinaryHeap() : base()
        {
            _array = new T[0];
            Size = 0;
        }

        public MaxBinaryHeap(int capacity) : base(capacity)
        {
            _array = new T[capacity];
            Size = 0;
        }

        public override void Insert(T item)
        {
            if (Size >= _array.Length)
            {
                Console.WriteLine("Heap is already full.");
                return;
            }

            _array[Size++] = item;
            HeapifyBottomToTop(Size - 1);
        }

        protected override void HeapifyBottomToTop(int index)
        {
            if (index == 0)
            {
                return;
            }

            int parent = index % 2 == 0 ? (index / 2) - 1 : index / 2;

            if (Utility<T>.Compare(_array[index], _array[parent]) == 1)
            {
                Utility<T>.Swap(ref _array[index], ref _array[parent]);
            }

            HeapifyBottomToTop(parent);
        }

        public override T Remove()
        {
            if (Size <= 0)
            {
                Console.WriteLine("Heap is already empty.");
                return default(T);
            }

            T item = _array[0];
            _array[0] = _array[Size - 1];
            Size--;

            HeapifyTopToBottom(0);

            return item;
        }

        protected override void HeapifyTopToBottom(int index)
        {
            int left = index * 2 + 1;
            int right = left + 1;
            int child = 0;

            if (left > Size)
            {
                return;
            }

            if (left == Size)
            {
                if (Utility<T>.Compare(_array[index], _array[left]) == -1)
                {
                    Utility<T>.Swap(ref _array[index], ref _array[left]);
                }

                return;
            }

            if (Utility<T>.Compare(_array[left], _array[right]) == 1)
            {
                child = left;
            }
            else
            {
                child = right;
            }

            if (Utility<T>.Compare(_array[index], _array[child]) == -1)
            {
                Utility<T>.Swap(ref _array[index], ref _array[child]);
            }

            HeapifyTopToBottom(child);
        }
    }
}
