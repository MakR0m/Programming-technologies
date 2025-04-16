using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DelegateAndEvent.FuncAndAction
{
    internal class Processor<T>
    {
        public List<T> Items { get; }

        public Processor(List<T> items)
        {
            Items = items;
        }

        public void ApplyAction(Action<T> action)
        {
            foreach (var item in Items)
                action(item);
        }

        public void Transform(Func<T,T> transformer)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i] = transformer(Items[i]);
            }
        }
    }
}
