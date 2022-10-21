using System.Collections;

namespace Stacks
{
    public class ArrayStack<T> : IEnumerable<T>
    {
        private readonly T[] _values;
        private int _count;

        public ArrayStack(int n)
        {
            _values = new T[n];
        }

        public bool IsEmpty { get => _count == 0; }
        public bool IsFull { get => _values.Length == _count; }

        public void Push(T value)
        {
            if (IsFull)
                throw new StackOverflowException("Стек переполнен");

            _values[_count++] = value;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new NullReferenceException("Стек пуст");

            var value = _values[--_count];
            _values[_count] = default;

            return value;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new NullReferenceException("Стек пуст");

            return _values[_count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (IsEmpty)
                throw new NullReferenceException("Стек пуст");

            for (int i = _count; i > 0; i--)
                yield return _values[i - 1];
        }

        IEnumerator IEnumerable.GetEnumerator() => _values.GetEnumerator();
    }
}