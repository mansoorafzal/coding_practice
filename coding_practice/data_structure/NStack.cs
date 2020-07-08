using System;
using System.Collections.Generic;

namespace coding_practice.data_structure
{
    public class NStack<T>
    {
        private T[][] _array;
        private int _capacity;
        private Dictionary<int, int> _indices;

        public NStack(int totalStacks, int capacity)
        {
            _array = new T[totalStacks][];
            _capacity = capacity;
            _indices = new Dictionary<int, int>();
        }

        public int Count { get; private set; }

        public void Push(int stackIndex, T item)
        {
            if (Count >= _capacity)
            {
                Console.WriteLine("Stack is full!");
                return;
            }

            int index = GetDictionaryValue(stackIndex);

            if (index == -1)
            {
                _array[stackIndex] = new T[_capacity];
            }

            _array[stackIndex][++index] = item;
            _indices[stackIndex] = index;

            Count++;
        }

        public T Pop(int stackIndex)
        {
            T item = default(T);

            if (Count <= 0)
            {
                Console.WriteLine("Stack is empty!");
                return item;
            }

            if (Count > 0)
            {
                int index = GetDictionaryValue(stackIndex);

                if (index >= 0)
                {
                    item = _array[stackIndex][index--];
                    _indices[stackIndex] = index;

                    Count--;
                }
            }

            return item;
        }

        public T Peek(int stackIndex)
        {
            T item = default(T);

            if (Count < 0)
            {
                Console.WriteLine("Stack is empty!");
                return item;
            }

            if (Count > 0)
            {
                int index = GetDictionaryValue(stackIndex);

                if (index >= 0)
                {
                    item = _array[stackIndex][index];
                }
            }

            return item;
        }

        private int GetDictionaryValue(int key)
        {
            int value = -1;

            if (!_indices.TryGetValue(key, out value))
            {
                value = -1;
            }

            return value;
        }
    }
}
