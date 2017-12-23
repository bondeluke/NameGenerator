using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNameGenerator
{
    public class HashList<T> : ICollection<T>
    {
        private readonly Collection<T>[] _hashtable;
        private readonly int _size;

        public HashList(int size)
        {
            _size = size;
            _hashtable = new Collection<T>[_size];
        }

        private ICollection<T> _internalCollection
        {
            get { return _hashtable.WhereInstantiated().SelectMany(x => x).ToArray(); }
        }

        public void Add(T item)
        {
            var hashKey = GetHashKey(item);
            var collection = _hashtable[hashKey];

            if (collection.IsInstantiated())
                collection.Add(item);
            else
                _hashtable[hashKey] = new Collection<T> { item };
        }

        public void Clear()
        {
            for (int i = 0; i < _size; i++)
            {
                if (_hashtable[i].IsInstantiated())
                {
                    _hashtable[i].Clear();
                    _hashtable[i] = null;
                }
            }
        }

        public bool Contains(T item)
        {
            var collection = _hashtable[GetHashKey(item)];

            return collection.IsInstantiated() && collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _internalCollection.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _internalCollection.Count; }
        }

        public bool IsReadOnly
        {
            get { return _hashtable.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            var hashKey = GetHashKey(item);

            return _hashtable[hashKey].IsInstantiated() && _hashtable[hashKey].Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _internalCollection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GetHashKey(T item)
        {
            return item.GetHashCode().Mod(_size);
        }
    }
}
