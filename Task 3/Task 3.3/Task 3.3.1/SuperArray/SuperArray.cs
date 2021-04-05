using System;
using System.Collections.Generic;                  
using System.Linq;                                 
using System.Text;                                 
using System.Threading.Tasks;                      
                                                   
namespace SuperArray                               
{                                                  
    public static class SuperArray                 
    {
        #region ByteArrayExtensions
        public static int GetArraySum(this byte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            int sum = 0;

            foreach (var item in array)
                sum += item;

            return sum;
        }

        public static byte GetMean(this byte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return (byte)(array.GetArraySum() / array.Length);
        }

        public static byte GetMode(this byte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<byte, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(byte[] array, byte value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion

        #region SbyteArrayExtensions
        public static int GetArraySum(this sbyte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            int sum = 0;

            foreach (var item in array)
                sum += item;

            return sum;
        }

        public static sbyte GetMean(this sbyte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return (sbyte)(array.GetArraySum() / array.Length);
        }

        public static sbyte GetMode(this sbyte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<sbyte, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(sbyte[] array, sbyte value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion

        #region ShortArrayExtensions
        public static int GetArraySum(this short[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            int sum = 0;

            foreach (var item in array)
                sum += item;

            return sum;
        }

        public static short GetMean(this short[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return (short)(array.GetArraySum() / array.Length);
        }

        public static short GetMode(this short[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<short, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(short[] array, short value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion

        #region UshortArrayExtensions
        public static int GetArraySum(this ushort[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            int sum = 0;

            foreach (var item in array)
                sum += item;

            return sum;
        }

        public static ushort GetMean(this ushort[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return (ushort)(array.GetArraySum() / array.Length);
        }

        public static ushort GetMode(this ushort[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<ushort, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(ushort[] array, ushort value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion

        #region UintArrayExtensions
        public static uint GetArraySum(this uint[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            uint sum = 0;

            foreach (var item in array)
                sum += item;

            return sum;
        }

        public static uint GetMean(this uint[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.GetArraySum() / (uint)array.Length;
        }

        public static uint GetMode(this uint[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<uint, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(uint[] array, uint value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion

        #region IntArrayExtensions
        public static int GetArraySum(this int[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum();
        }

        public static int GetMean(this int[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.Sum() / array.Length;
        }

        public static int GetMode(this int[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<int, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(int[] array, int value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion

        #region UlongArrayExtensions
        public static ulong GetArraySum(this ulong[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            ulong sum = 0;

            foreach (var item in array)
                sum += item;

            return sum;
        }

        public static ulong GetMean(this ulong[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.GetArraySum() / (ulong)array.Length;
        }

        public static ulong GetMode(this ulong[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<ulong, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(ulong[] array, ulong value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion

        #region LongArrayExtensions
        public static long GetArraySum(this long[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            long sum = 0;

            foreach (var item in array)
                sum += item;

            return sum;
        }

        public static long GetMean(this long[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.GetArraySum() / array.Length;
        }

        public static long GetMode(this long[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<long, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(long[] array, long value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion

        #region FloatArrayExtensions
        public static float GetArraySum(this float[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum();
        }

        public static float GetMean(this float[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.Sum() / array.Length;
        }

        public static float GetMode(this float[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<float, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(float[] array, float value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion

        #region DoubleArrayExtensions
        public static double GetArraySum(this double[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum();
        }

        public static double GetMean(this double[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.Sum() / array.Length;
        }

        public static double GetMode(this double[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<double, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(double[] array, double value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion

        #region DecimalArrayExtensions
        public static decimal GetArraySum(this decimal[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum();
        }

        public static decimal GetMean(this decimal[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.Sum() / array.Length;
        }

        public static decimal GetMode(this decimal[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            var dictionary = new Dictionary<decimal, int>();

            foreach (var item in array)
            {
                if (!dictionary.ContainsKey(item))
                    dictionary.Add(item, GetValueCount(array, item));
            }

            return dictionary.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        private static int GetValueCount(decimal[] array, decimal value)
        {
            var count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                    count++;
            }
            return count;
        }
        #endregion
    }
}
