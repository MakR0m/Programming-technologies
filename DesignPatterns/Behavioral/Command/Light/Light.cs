using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Light
{
    internal class Light
    {
        public void TurnOn() => Console.WriteLine("[Лампа] Включена");
        public void TurnOff() => Console.WriteLine("[Лампа] Выключена");
    }
}
