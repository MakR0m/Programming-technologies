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

        public override void Introduce() //Если использовать new, а не override, то при приведении к классу родителя будет вызываться родительский метод.
                                         //Нью - скрытие. Это уже не полиморфизм. Нью и без virtual можно использовать
        {
            Console.WriteLine($"Меня зовут {Name}, я учусь в {Grade} классе");
        }
    }
}
