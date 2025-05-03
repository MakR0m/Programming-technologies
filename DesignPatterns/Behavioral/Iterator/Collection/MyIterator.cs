namespace DesignPatterns.Behavioral.Iterator.Collection
{
    internal class MyIterator<T> : IIterator<T>
    {
        private readonly List<T> _items;
        private int _index = 0;

        public MyIterator(List<T> items) => _items = items;

        public bool HasNext() => _index < _items.Count;

        public T Next() => _items[_index++];
    }
}