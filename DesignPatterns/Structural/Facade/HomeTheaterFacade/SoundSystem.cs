using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Facade.HomeTheaterFacade
{
    public class SoundSystem
    {
        public void TurnOn() => Console.WriteLine("Аудиосистема включена");
        public void SetVolume(int level) => Console.WriteLine($"Громкость установлена: {level}");
    }
}
