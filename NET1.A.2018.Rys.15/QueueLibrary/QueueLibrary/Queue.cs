using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace QueueLibrary
{
    public class Queue<T> : IEnumerable<T>, IEnumerable
    {
        #region private fields

        private int _tail;
        private int _head;
        private int _size;

        private T[] _array;
        private int _version;

        #endregion

        #region const fields

        private const int _DefaultSize = 4;
        private const int _GrowthFactor = 2;

        #endregion

        public int Count
        {
            get => this._size;
        }

        /// <summary>
        /// Creating the queue with default size.
        /// </summary>
        public Queue()
        {
            _array = new T[_DefaultSize];
        }

        /// <summary>
        /// Creating sized queue.
        /// </summary>
        public Queue(int capasity)
        {
            if (capasity < 0)
                throw new ArgumentOutOfRangeException(nameof(capasity), " capasity must be grater that zero!");
            _array = new T[capasity];
            _head = 0;
            _tail = 0;
            _size = 0;
        }

        /// <summary>
        /// Check queue from empty
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty() => _size == 0;

        /// <summary>
        /// Clear queue
        /// </summary>
        public void Clear()
        {
            if (_size == 0)
                return;

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
            if (this._size == this._array.Length)
            {
                int capacity = (int)((long)this._array.Length * 200L / 100L);
                if (capacity < this._array.Length + 4)
                    capacity = this._array.Length + 4;
                this.SetCapacity(capacity);
            }

            _array[_tail] = item;
            _tail = (_tail + 1) % _array.Length;

            _size++;
            _version++;
        }

        /// <summary>
        /// Get value from Queue.
        /// </summary>
        /// <returns> Returns the first elemt of queue. </returns>
        public T Dequeue()
        {
            if (_size == 0) throw new ArgumentException($"{Count} is 0");

            T value = _array[_head];
            _array[_head++] = default(T);

            _size--;
            _version++;

            return value;
        }

        /// <summary>
        /// Returns the string version of queue.
        /// </summary>
        /// <returns> String equation of an array. </returns>
        public override string ToString()
        {
            var resultStr = "";
            foreach (var item in _array)
            {
                resultStr += item.ToString() + ", ";
            }

            return "[" + resultStr.Remove(resultStr.Length - 2, 2) + "]";
        }

        /// <summary>
        /// Returns the hash code of the queue.
        /// </summary>
        /// <returns> Int hash of a queue. </returns>
        public override int GetHashCode()
        {
            return _array.GetHashCode().GetHashCode();
        }

        /// <summary>
        /// Represents method for getting iterator for Queue.
        /// </summary>
        /// <returns> Returns the itarator. </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator(this);
        }

        /// <summary>
        /// Represents method for getting iterator for Queue.
        /// </summary>
        /// <returns> Retrurns an interface link of iterator. </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #region Queue Iterator  
        /// <summary>
        /// Represents structure to implement iterator
        /// </summary>
        private struct QueueIterator : IEnumerator<T>
        {
            private Queue<T> _queue;
            private int _currentIndex;
            private int _index;

            public T Current => _queue[_currentIndex];

            public QueueIterator(Queue<T> qivenQueue)
            {
                _currentIndex = qivenQueue._head - 1;
                _queue = qivenQueue;
                _index = 0;
            }

            object IEnumerator.Current => Current;

            public void Dispose() => Reset();

            /*
                if (_currentIndex < (_queue._array.Length - 1))
                {
                    _currentIndex = (_currentIndex + 1) % _queue._array.Length;
                    return true;
                }

                return false;
             */

            public bool MoveNext()
            {
                // TODO
                // add index to count the items in the array
                // do IF(idenx > queue.size) 
                if (_index < _queue._size)
                {
                    _currentIndex = (_currentIndex + 1) % _queue._array.Length;
                    _index++;
                    return true;
                }

                return false;
            }

            public void Reset() => _currentIndex = _queue._head - 1;
        }
        #endregion

        private T this[int i]
        {
            get => _array[i];
            set => _array[i] = value;
        }

        /// <summary>
        /// Resize the current array of the Queue.
        /// </summary>
        /// <param name="capacity"> New capasity of the array. </param>
        private void SetCapacity(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            var resizedArray = new T[capacity];
            if (_head < _tail)
            {
                Array.Copy(_array, 0, resizedArray, 0, _array.Length);
            }
            else
            {
                Array.Copy(_array, _head, resizedArray, 0, _array.Length - _head);
                Array.Copy(_array, 0, resizedArray, _array.Length - _head, _tail);
                _tail = _size;
                _head = 0;
            }

            _array = resizedArray;
            _version++;
        }
    }
}