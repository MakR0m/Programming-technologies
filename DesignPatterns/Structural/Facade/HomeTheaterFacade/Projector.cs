using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Facade.HomeTheaterFacade
{
    public class Projector
    {
        public void TurnOn() => Console.WriteLine("Проектор включен");
        public void SetInput(string source) => Console.WriteLine($"Источник установлен: {source}");
    }
}
