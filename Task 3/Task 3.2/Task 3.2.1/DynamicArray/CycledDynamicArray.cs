using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray()
            : base()
        {
        }

        public CycledDynamicArray(int capacity)
            : base(capacity)
        {
        }

        public CycledDynamicArray(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public new IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(_array);
        }

        public class Enumerator : IEnumerator<T>
        {
            private readonly T[] _collection;
            private int _curIndex;
            private T _curObject;

            public Enumerator(T[] collection)
            {
                _collection = collection;
                _curIndex = -1;
                _curObject = default(T);
            }

            public T Current => _curObject;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (++_curIndex >= _collection.Length)
                    _curIndex = 0;

                _curObject = _collection[_curIndex];

                return true;
            }

            public void Reset()
            {
                _curIndex = -1;
                _curObject = default(T);
            }
        }
    }
}
