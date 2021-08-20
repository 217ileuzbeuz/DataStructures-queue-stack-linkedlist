using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack<T>
    {
        private T[] _array;
        private int _size;
        private float _growFactor;
        private const int _defaultcapacity = 4;
        public Stack() : this(0, 2)
        {

        }
        public Stack(int capacity) : this(capacity, 2)
        {

        }
        public Stack(int capacity, float growFactor)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (growFactor <= 1)
            {
                throw new ArgumentOutOfRangeException();
            }
            _array = new T[capacity];
            _growFactor = growFactor * 100;
            _size = 0;
        }

        public int Count { get { return _size; } }
        public void Clear()
        {
            Array.Clear(_array, 0, _size);
            _size = 0;
        }
        public void Push(T item)
        {

            if (_size == _array.Length)
            {
                T[] newArray = new T[(_size == 0) ? _defaultcapacity : (int)_growFactor * _array.Length / 100];
                Array.Copy(_array, 0, newArray, 0, _size);
                _array = newArray;
            }
            _array[_size++] = item;
        }
        public T Keep()
        {
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            return _array[_size - 1];
        }
        public T Pop()
        {
            if (_size == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            T item = _array[--_size];
            _array[_size] = default(T);
            return item;
        }
    }
}
