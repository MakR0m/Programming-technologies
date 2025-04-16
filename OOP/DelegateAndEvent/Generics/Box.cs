using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DelegateAndEvent.Generics
{
    internal class Box<T>
    {
        public T Content { get; set; }

        public Box(T content)
        {
            Content = content;
        }
        
        public void Print()
        {
            Console.WriteLine($"Содержимое {Content}");
        }
    }
}
