using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Teacher : Person
    {
        public string Subject { get; set; }

        public Teacher(string subject, string name, int age) : base(name, age)
        {
            Subject = subject;
        }

        public override void Introduce()
        {
            Console.WriteLine($"Меня зовут {Name}, я преподаю {Subject}");
        }
    }
}
