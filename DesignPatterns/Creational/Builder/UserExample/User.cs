using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Builder.UserExample
{
    public class User
    {
        public string Name { get; }
        public string Email { get; }
        public int Age { get; }
        public string Address {  get; }

        internal User(string name, string email, int age, string address)   // Доступен только внутри сборки
        {
            Name = name;
            Email = email;
            Age = age;
            Address = address;
        }

        public override string ToString() => $"{Name}, {Email}, {Age} лет, {Address}";
    }
}
