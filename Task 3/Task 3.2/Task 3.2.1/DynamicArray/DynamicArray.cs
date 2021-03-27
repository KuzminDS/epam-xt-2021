using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    public class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        protected T[] _array;
        private int _capacity;

        public int Length { get; private set; }

        public int Capacity
        {
            get { return _capacity; }

            set
            {
                if (value < 0)
                    throw new Exception("Capacity cannot be negative");

                _capacity = value;
                if (_capacity < Length)
                {
                    Length = _capacity;

                    _array = GetArrayCopy(_array, _capacity, Length);
                }
            }
        }

        public T this[int i]
        {
            get
            {
                if (i < 0)
                    return _array[Length + i];
                else
                    return _array[i];
            }

            set
            {
                if (i < 0)
                    _array[Length + i] = value;
                else
                    _array[i] = value;
            }
        }

        public DynamicArray()
        {
            Capacity = 8;
            Length = 0;
            _array = new T[8];
        }

        public DynamicArray(int capacity)
        {
            Capacity = capacity;
            Length = 0;
            _array = new T[capacity];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            Capacity = collection.Count();
            Length = Capacity;
            _array = new T[Capacity];

            Array.Copy(collection.ToArray(), _array, Capacity);
        }


        public void Add(T item)
        {
            Insert(Length, item);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            if (Length + collection.Count() > Capacity)
            {
                Capacity = (Length + collection.Count()) * 2;

                _array = GetArrayCopy(_array, Capacity, Length);
                //var newArray = new T[Capacity];
                //Array.Copy(_array, newArray, Length);
                //_array = newArray;
            }

            Array.Copy(collection.ToArray(), 0, _array, Length, collection.Count());
            Length += collection.Count();
        }

        public bool Remove(T item)
        {
            var itemIndex = Array.IndexOf(_array, item);

            if (itemIndex == -1)
                return false;

            for (int i = itemIndex; i < Length - 1; i++)
                _array[i] = _array[i + 1];

            _array[Length - 1] = default(T);
            Length--;

            return true;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Length)
                throw new ArgumentOutOfRangeException("Argument cannot be inserted at the specified position");

            if (Length + 1 > Capacity)
            {
                Capacity = (Length + 1) * 2;
                _array = GetArrayCopy(_array, Capacity, Length);

            }

            for (int i = Length; i > index; i--)
                _array[i] = _array[i - 1];

            _array[index] = item;
            Length++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            return new DynamicArray<T>(_array);
        }

        public T[] ToArray()
        {
            return GetArrayCopy(_array, Length, Length);
        }

        protected T[] GetArrayCopy(T[] sourceArray, int capacity, int length)
        {
            var newArray = new T[capacity];
            Array.Copy(sourceArray, newArray, length);
            return newArray;
        }

    }
}
