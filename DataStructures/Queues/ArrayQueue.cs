using System.Collections;

namespace Queues
{
    public class ArrayQueue<T> : IEnumerable<T>
    {
        private readonly T[] _values;
        private int _count;
        private const int IndexFirstElement = 0;

        public ArrayQueue(int n)
        {
            _count = 0;
            _values = new T[n];
        }

        public bool IsFull { get => _values.Length == _count; }
        public bool IsEmpty { get => _count == 0; }

        public void Enqueue(T value)
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            if (IsFull)
                throw new StackOverflowException();

            var oldElement = _values[IndexFirstElement];

            _count++;

            if (_count == 1)
            {
                _values[IndexFirstElement] = value;
                return;
            }

            for (int i = 0; i < _count; i++)
            {
                if (_count == 1 || i == _count - 1)
                    _values[i] = value;
                else
                    _values[i] = oldElement;

                int nextIndex = i + 1;

                if (nextIndex == _count)
                    break;

                oldElement = _values[nextIndex];
            }
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new NullReferenceException();

            var value = _values[IndexFirstElement];
            _values[IndexFirstElement] = default;

            for (int i = 1; i < _values.Length; i++)
            {
                var oldElement = _values[i];

                int preIndex = i - 1;
                if (preIndex == 0)
                    _values[preIndex] = _values[i];
                else
                    _values[preIndex] = oldElement;
            }

            _count--;

            return value;
        }

        public T Peek() => IsEmpty ? throw new NullReferenceException() : _values[IndexFirstElement];

        public IEnumerator<T> GetEnumerator()
        {
            if (IsEmpty)
                throw new NullReferenceException();

            for (int i = 0; i < _count; i++)
                yield return _values[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}