using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DelegateAndEvent
{
    public delegate void ThresholdReachedHandler (object sender, ThresholdReachedEventArgs e);  // Обработчик достижения порога.  Делегат используется для определения сигнатуры обработчика события.

    public class ThresholdReachedEventArgs : EventArgs   //EventArgs-класс для передачи информации в событии
    {
        public int Threshold { get; }
        public DateTime TimeReached { get; }

        public ThresholdReachedEventArgs(int threshold)  //Аргументы события достижения порога
        {
            Threshold = threshold;
            TimeReached = DateTime.Now;
        }
    }

    internal class Counter
    {
        private int _count;
        private readonly int _threshold;

        public Counter(int threshold)
        {
            _threshold = threshold;
        }

        public event ThresholdReachedHandler ThresholdReached;  //Событие инкапсулирует вызов делегатов (подписчиков).

        public void Add(int value)
        {
            _count += value;
            Console.WriteLine($"Текущее значение: {_count}");
            if (_count >= _threshold)
            {
                ThresholdReached?.Invoke(this, new ThresholdReachedEventArgs(_threshold));  //?.Invoke() — безопасный вызов события, если на него кто-то подписан
            }
        }

    }
}
