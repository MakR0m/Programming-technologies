using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Iterator.Collection
{
    internal class MyCollection<T>
    {
        private List<T> _items = new List<T>();
        public void Add(T item) => _items.Add(item);

        public IIterator<T> GetIterator() => new MyIterator<T>(_items); 
    }
}
