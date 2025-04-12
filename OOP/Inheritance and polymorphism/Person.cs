using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Person
    {
        public string Name { get; set; }

        private int age;
        public int Age
        { get => age; 
            set 
            { 
                if (value < 0)
                    throw new ArgumentException("Must be above zero");
                age = value;
            } 
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age; 
        }

        public virtual void Introduce()
        {
            Console.WriteLine($"Меня зовут {Name} мне {Age} лет");
        }

    }
}
