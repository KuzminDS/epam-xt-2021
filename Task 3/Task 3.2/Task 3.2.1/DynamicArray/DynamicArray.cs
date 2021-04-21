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


        /// <summary>
        /// Capacity represents the actual size of the array.
        /// Changing this property can lead to losing data.
        /// Before changing it use the EnsureCapacity method
        /// </summary>
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
                {
                    if (i < -Length)
                        throw new IndexOutOfRangeException();
                    return _array[Length + i];
                }
                else
                {
                    if (i >= Length)
                        throw new IndexOutOfRangeException();
                    return _array[i];
                }
            }

            set
            {
                if (i < 0)
                {
                    if (i < -Length)
                        throw new IndexOutOfRangeException();
                    _array[Length + i] = value;
                }
                else
                {
                    if (i >= Length)
                        throw new IndexOutOfRangeException();
                    _array[i] = value;
                }
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
            _array = collection.ToArray();

            Capacity = _array.Length;
            Length = _array.Length;
        }


        /// <summary>
        /// Method returns true if new capacity doesn't lead to losing data and change capacity otherwise returns fasle
        /// </summary>
        public bool EnsureCapacity(int newCapacity)
        {
            if (newCapacity >= Length)
            {
                Capacity = newCapacity;
                return true;
            }
            return false;
        }

        public void Add(T item)
        {
            Insert(Length, item);
        }

        public void AddRange(IEnumerable<T> collection)
        {
            var tempArray = collection.ToArray();

            if (Length + tempArray.Length > Capacity)
            {
                Capacity = (Length + tempArray.Length) * 2;

                _array = GetArrayCopy(_array, Capacity, Length);
            }

            Array.Copy(tempArray, 0, _array, Length, tempArray.Length);
            Length += tempArray.Length;
        }

        public bool Remove(T item)
        {
            var itemIndex = Array.IndexOf(_array, item);

            if (itemIndex == -1)
                return false;

            Array.Copy(_array, itemIndex + 1, _array, itemIndex, Length - 1 - itemIndex);

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

        public virtual IEnumerator<T> GetEnumerator()
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
