using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Student : Person
    {
        public string Grade {  get; set; }

        public Student(string grade, string name, int age) : base(name, age)
        {
            Grade = grade;
        }

        public override void Introduce()
        {
            Console.WriteLine($"Меня зовут {Name}, я учусь в {Grade} классе");
        }
    }
}
