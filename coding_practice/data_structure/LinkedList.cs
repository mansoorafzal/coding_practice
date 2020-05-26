using coding_practice.helper;
using System;

namespace coding_practice.data_structure
{
    public class LinkedList<T>
    {
        private Node<T> _root;
        private T[] _array;

        public LinkedList()
        {
            _root = null;
            _array = null;
            Count = 0;
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                T item = default(T);

                if (index < Count)
                {   
                    item = _array[index];
                }

                return item;
            }
        }

        public void InsertFirst(T item)
        {
            if (_root == null)
            {
                _root = new Node<T>(item);
            }
            else
            {
                Node<T> node = new Node<T>(item);
                node.Next = _root;
                _root = node;
            }

            Count++;

            ToArray();
        }

        public void InsertLast(T item)
        {
            if (_root == null)
            {
                _root = new Node<T>(item);
            }
            else
            {
                Node<T> node = _root;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = new Node<T>(item);
            }

            Count++;

            ToArray();
        }

        public T GetFirst()
        {
            T item = default(T);

            if (_root != null)
            {
                item = _root.Item;
            }

            return item;
        }

        public T FindFirst(T item)
        {
            Node<T> node = _root;

            while (node != null)
            {
                if (Utility<T>.Compare(item, node.Item) == 0)
                {
                    break;
                }

                node = node.Next;
            }

            if (node == null)
            {
                return default(T);
            }

            return node.Item;
        }

        public bool IsExist(T item)
        {
            Node<T> node = _root;

            while (node != null)
            {
                if (Utility<T>.Compare(item, node.Item) == 0)
                {
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public void RemoveFirst()
        {
            Node<T> node = _root;

            if (_root.Next == null)
            {
                _root = null;
            }
            else
            {
                _root = _root.Next;
                node = null;
            }

            Count--;

            ToArray();
        }

        public void RemoveLast()
        {
            Node<T> node = _root;

            if (_root.Next == null)
            {
                _root = null;
            }
            else
            {
                Node<T> temp = null;

                while (node.Next != null)
                {
                    temp = node;
                    node = node.Next;
                }

                node = null;
                temp.Next = null;
            }

            Count--;

            ToArray();
        }

        public void PrintRegular()
        {
            Node<T> node = _root;

            Console.Write("ROOT --> ");

            while (node != null)
            {
                Console.Write(node.Item + " --> ");
                node = node.Next;
            }

            Console.WriteLine("NULL");
        }

        public void PrintReverse()
        {
            Console.Write("NULL");

            PrintReverse(_root);

            Console.WriteLine(" <-- ROOT");
        }

        private void PrintReverse(Node<T> node)
        {
            if (node != null)
            {
                PrintReverse(node.Next);
                Console.Write(" <-- " + node.Item);
            }
        }

        private void ToArray()
        {
            T[] array = new T[Count];
            int i = 0;

            Node<T> node = _root;

            while (node != null)
            {
                array[i++] = node.Item;
                node = node.Next;
            }

            _array = array;
        }

        // TODO - not working (edges are not cloned properly)
        //public LinkedList<T> Clone()
        //{
        //    LinkedList<T> linkedList = new LinkedList<T>();

        //    if (_array != null)
        //    {
        //        for (int i = 0; i < _array.Length; i++)
        //        {
        //            T item = (T)Activator.CreateInstance(typeof(T), _array[i]);

        //            linkedList.InsertLast(item);
        //        }
        //    }

        //    return linkedList;
        //}
    }
}
