using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer.EventsObserver
{
    public class AnotherTemperatureSensor
    {
        public event Action<float> TemperatureChanged;
        private float _temperature;

        public void SetTemperature (float temperature)
        {
            _temperature = temperature;
            Console.WriteLine($"\n[Датчик] Температура изменилась: {_temperature}°C");
            TemperatureChanged?.Invoke( _temperature );
        }
    }

    public class AnotherMobileApp
    {
        public void OnTemperatureChanged(float temperature)
        {
            Console.WriteLine($"[Мобильное приложение] Новая температура: {temperature}°C");
        }
    }

    public class AnotherTemperatureLogger
    {
        public void OnTemperatureChanged(float temperature)
        {
            Console.WriteLine($"[Логгер] Запись в журнал: {temperature}°C");
        }
    }
}
