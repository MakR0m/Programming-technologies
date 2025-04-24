using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Facade.HomeTheaterFacade
{
    internal class HomeTheaterFacade
    {
        private readonly Projector _projector;
        private readonly SoundSystem _sound;
        private readonly Screen _screen;

        public HomeTheaterFacade(Projector projector, SoundSystem sound, Screen screen)
        {
            _projector = projector;
            _sound = sound;
            _screen = screen;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine($"Готовим просмотр: {movie}");
            _screen.Lower();
            _projector.TurnOn();
            _projector.SetInput("HDMI");
            _sound.TurnOn();
            _sound.SetVolume(7);
            Console.WriteLine($"Фильм \"{movie}\" запущен!");
        }
    }
}
