using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Queue<T>
    {
        private T[] _array;
        private int _size;
        private int _head;
        private int _tail;
        private float _growFactor;
        private const int _defaultcapacity = 4;
        public Queue() : this(0, 2)
        {

        }
        public Queue(int capacity) : this(capacity, 2)
        {

        }
        public Queue(int capacity, float growFactor)
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
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        public int Count { get { return _size; } }
        public void Clear()
        {
            if (_head < _tail)
                Array.Clear(_array, _head, _size);
            else
            {
                Array.Clear(_array, _head, _array.Length - _head);
                Array.Clear(_array, 0, _tail);
            }

            _head = 0;
            _tail = 0;
            _size = 0;
        }
        public void EnQeueue(T item)
        {

            if (_size == _array.Length)
            {
                int newcapacity = (int)((long)_array.Length * (long)_growFactor / 100);
                if (newcapacity < _array.Length + _defaultcapacity)
                {
                    newcapacity = _array.Length + _defaultcapacity;
                }
                SetCapacity(newcapacity);
            }

            _array[_tail++] = item;
            _size++;
        }
        private void SetCapacity(int capacity)
        {
            T[] newarray = new T[capacity];
            if (_size > 0)
            {
                Array.Copy(_array, _head, newarray, 0, _size);
            }

            _array = newarray;
            _head = 0;
            _tail = (_size == capacity) ? 0 : _size;
        }

        public T Keep()
        {
            if (_size == 0)
                throw new ArgumentOutOfRangeException();

            return _array[_head];
        }
        public T DeQueue()
        {
            if (_size == 0)
                throw new ArgumentOutOfRangeException();

            T removed = _array[_head];
            _array[_head] = default(T);
            _head = (_head + 1);
            _size--;
            return removed;
        }
    }
}
