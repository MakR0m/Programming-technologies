using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Observer.ObserverWithoutEvents
{
    internal interface IObserver
    {
        void Update(float temperature);
    }
}
