using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStringLibrary   //task with ** dll works correctly with other project
{
    public class CustomString : IComparable<CustomString>, IEquatable<CustomString>
    {
        private readonly char[] _charArray;

        public CustomString()
        {
            _charArray = new char[0];
        }

        public CustomString(int count)
        {
            _charArray = new char[count];
        }

        public CustomString(params char[] charArray)
        {
            _charArray = new char[charArray.Length];
            charArray.CopyTo(_charArray, 0);
        }

        public CustomString(string str)
        {
            _charArray = new char[str.Length];
            str.CopyTo(0, _charArray, 0, str.Length);
        }

        public CustomString(CustomString customString)
            : this(customString._charArray)
        {
        }

        public int Length => _charArray.Length;

        public int CompareTo(CustomString other)
        {
            int minLenght = Math.Min(this._charArray.Length, other._charArray.Length);

            for (int i = 0; i < minLenght; i++)
            {
                var result = this._charArray[i].CompareTo(other._charArray[i]);

                if (result != 0)
                    return result;
            }

            return this._charArray.Length.CompareTo(other._charArray.Length);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) 
                return false;

            CustomString str = obj as CustomString;
            return this.Equals(str); 
        }

        public bool Equals(CustomString other)
        {
            return this.CompareTo(other) == 0;
        }

        public CustomString Concat(CustomString other)
        {
            var result = new CustomString(this._charArray.Length + other._charArray.Length);
            this._charArray.CopyTo(result._charArray, 0);
            other._charArray.CopyTo(result._charArray, this._charArray.Length);
            return result;
        }

        public int IndexOf(char value)
        {
            for (int i = 0; i < _charArray.Length; i++)
            {
                if (_charArray[i] == value)
                    return i;
            }
            return -1;
        }

        public int LastIndexOf(char value)
        {
            for (int i = _charArray.Length - 1; i >= 0; i--)
            {
                if (_charArray[i] == value)
                    return i;
            }
            return -1;
        }

        public bool Contains(char value)
        {
            return IndexOf(value) != -1;
        }

        public char[] ToCharArray()
        {
            var result = new char[_charArray.Length];
            Array.Copy(_charArray, result, _charArray.Length);
            return result;
        }

        public int GetCountOfWords() //additional method 
        {
            int count = 0;
            for (int i = 0; i < _charArray.Length; i++)
            {
                if(IsLetterOrDigit(_charArray[i]))
                {
                    count++;
                    while (i < _charArray.Length && IsLetterOrDigit(_charArray[i]))
                        i++;
                }
            }
            return count;
        }

        public override string ToString()
        {
            return new string(_charArray);
        }

        public char this[int i] // task with * indexer
        {
            get { return _charArray[i]; }
            set { _charArray[i] = value; }
        }

        public static CustomString operator +(CustomString first, CustomString second)
            => first.Concat(second);

        public static bool operator ==(CustomString first, CustomString second)
            => first.Equals(second);

        public static bool operator !=(CustomString first, CustomString second)
            => !first.Equals(second);

        private bool IsLetterOrDigit(char symbol)
        {
            return char.IsLetter(symbol) || char.IsDigit(symbol);
        }
    }
}
