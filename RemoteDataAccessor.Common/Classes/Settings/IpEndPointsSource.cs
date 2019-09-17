using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDataAccessor.Common.Classes.Settings
{
    public sealed class IpEndPointsSource<T>
    {
        private readonly T[] _buffer;
        private int _head;
        private int _tail;

        private static readonly object _instancelock = new object();
        private static object _readWriteLock = new object();

        private readonly int _capacity;

        private IpEndPointsSource(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "must be positive");
            }

            _capacity = capacity;

            _buffer = new T[_capacity];
            _head = capacity - 1;
        }
        private static IpEndPointsSource<T> _instance;

        public static IpEndPointsSource<T> GetInstance
        {
            get
            {
                lock (_instancelock)
                {
                    if (_instance == null)
                    {
                        throw new Exception("Object not created");
                    }

                    return _instance;
                }
            }
        }

        public void Enqueue(T item)
        {
            lock (_readWriteLock)
            {
                _head = (_head + 1) % _capacity;
                _buffer[_head] = item;

                if (Count == _capacity)
                {
                    _tail = (_tail + 1) % _capacity;
                }
                else
                {
                    ++Count;
                }
            }
        }

        public static void Create(int capacity)
        {
            lock (_instancelock)
            {
                if (_instance != null)
                {
                    throw new Exception("Object already created");
                }

                _instance = new IpEndPointsSource<T>(capacity);
            }
        }

        public T GetNextItem()
        {
            lock (_readWriteLock)
            {
                _head = (_head + 1) % _capacity;
                _tail = (_tail + 1) % _capacity;

                return _buffer[_head];
            }
        }

        public int Count { get; private set; }
    }
}
