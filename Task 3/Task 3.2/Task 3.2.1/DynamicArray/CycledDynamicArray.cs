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

        public override IEnumerator<T> GetEnumerator()
        {
            var count = _array.Length;
            var index = 0;

            while (true)
            {
                yield return _array[index];
                index = (index + 1) % count;
            }
        }
    }
}
