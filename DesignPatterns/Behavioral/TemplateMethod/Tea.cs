using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.TemplateMethod
{
    internal class Tea : Drink
    {
        protected override void AddCondiments() => Console.WriteLine("Добавляем лимон");
        protected override void Brew() => Console.WriteLine("Завариваем чай");
    }
}
