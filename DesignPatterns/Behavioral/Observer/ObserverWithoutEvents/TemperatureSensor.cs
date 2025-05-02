using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer.ObserverWithoutEvents
{
    internal class TemperatureSensor : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        private float _temperature;

        public void SetTemperature(float temperature)
        {
            _temperature = temperature;
            Console.WriteLine($"\n[Датчик] Температура изменилась: {_temperature}°C");
            Notify();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in _observers)
            {
                {
                    observer.Update(_temperature);
                }
            }
        }
    }
}
