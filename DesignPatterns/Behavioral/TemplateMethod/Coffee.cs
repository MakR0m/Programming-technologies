using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.TemplateMethod
{
    internal class Coffee : Drink
    {
        protected override void Brew() => Console.WriteLine("Варим кофе");
        protected override void AddCondiments() => Console.WriteLine("Добавляем сахар и молоко");
    }
}
