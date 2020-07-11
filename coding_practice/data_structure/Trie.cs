using System.Collections.Generic;

namespace coding_practice.data_structure
{
    public class Trie<T>
    {
        private Dictionary<T, Trie<T>> _dictionary;

        public Trie()
        {
            _dictionary = new Dictionary<T, Trie<T>>();
        }

        public int Count
        {
            get
            {
                return _dictionary.Count;
            }
        }

        public bool HasChild(T item)
        {
            return _dictionary.ContainsKey(item);
        }

        public Trie<T> GetChild(T item)
        {
            if (HasChild(item))
            {
                return _dictionary[item];
            }

            return null;
        }

        public void AddChild(T item)
        {
            _dictionary[item] = new Trie<T>();
        }
    }
}
