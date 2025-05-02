using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer.ObserverWithoutEvents
{
    internal class TemperatureLogger : IObserver
    {
        public void Update(float temperature)
        {
            Console.WriteLine($"[Логгер] Запись в журнал: {temperature}°C");
        }
    }
}
