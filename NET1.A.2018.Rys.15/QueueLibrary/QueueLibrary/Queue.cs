using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueLibrary
{
    public class Queue<T> : IEnumerable<T>, IEnumerable
    {
        private static T[] _emptyArray = new T[0];
        
        private int _tail;
        private int _head;
        private int _size;
        private T[] _array;
        private int _version;

        private const int _DefaultSize = 4;
        private const int _GrowthFactor = 2;

        public int Count
        {
            get => this._size;
        }

        private T this[int i]
        {
            get => _array[i];
            set => _array[i] = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public Queue()
        {
            this._array = Queue<T>._emptyArray;
        }

        public Queue(int capasity)
        {
            if(capasity < 0) throw new ArgumentOutOfRangeException(nameof(capasity), " capasity must be grater that zero!");
            _array = new T[capasity];
            this._head = 0;
            this._tail = 0;
            this._size = 0;
        }

        /// <summary>
        /// Check queue from empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => _head == _tail;

        /// <summary>
        /// Clear queue
        /// </summary>
        public void Clear()
        {
            if (_size == 0)
            {
                return;
            }

            _size = _head = _tail = 0;
            Array.Clear(_array, 0, _array.Length);
            _version++;
        }

        /// <summary>
        /// Insert value to Queue
        /// </summary>
        /// <param name="item">Item what must be added</param>
        public void Enqueue(T item)
        {
            if (Count == _array.Length)
            {
                Array.Resize(ref _array, _size * _GrowthFactor);
            }

            _array[_tail++] = item;
            _size++;
            _version++;
        }

        /// <summary>
        /// Get value from Queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException($"{Count} is 0");
            }

            T value = _array[_head];
            _array[_head++] = default(T);
            _size--;
            _version++;

            return value;
        }

        /// <summary>
        /// Represents method for getting iterator for Queue
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator(this);
        }

        /// <summary>
        /// Represents method for getting iterator for Queue
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Represents structure to implement iterator
        /// </summary>
        private struct QueueIterator : IEnumerator<T>
        {
            private Queue<T> _queue;
            private int _currentIndex;

            public T Current => _queue[_currentIndex];

            public QueueIterator(Queue<T> qivenQueue)
            {
                _currentIndex = qivenQueue._head - 1;
                _queue = qivenQueue;
            }

            object IEnumerator.Current => Current;

            public void Dispose() => Reset();

            public bool MoveNext()
            {
                if (_currentIndex < _queue._array.Length - 1)
                {
                    _currentIndex++;
                    return true;
                }

                return false;
            }

            public void Reset() => _currentIndex = -1;
        }
    }
}