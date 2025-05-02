using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.TemplateMethod
{
    internal abstract class Drink
    {
        public void Prepare()
        {
            BoilWater(); // обычный метод
            Brew(); // абстрактный метод
            PourIntoCup(); //Обычный
            AddCondiments(); //Виртуальный
        }

        private void BoilWater() => Console.WriteLine("Кипятим воду");
        private void PourIntoCup() => Console.WriteLine("Наливаем в чашку");

        protected abstract void Brew();
        protected virtual void AddCondiments() { } // по умолчанию - ничего
    }
}
