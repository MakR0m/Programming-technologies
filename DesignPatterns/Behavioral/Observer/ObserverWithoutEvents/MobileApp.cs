using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer.ObserverWithoutEvents
{
    internal class MobileApp : IObserver
    {
        public void Update(float temperature)
        {
            Console.WriteLine($"[Мобильное приложение] Новая температура: {temperature}°C");
        }
    }
}
