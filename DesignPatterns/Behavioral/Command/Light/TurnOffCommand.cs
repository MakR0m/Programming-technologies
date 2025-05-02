using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Light
{
    internal class TurnOffCommand : ICommand
    {
        private readonly Light _light;

        public TurnOffCommand(Light light) => _light = light;

        public void Execute() => _light.TurnOff();
        public void Undo() => _light.TurnOn();
    }
}
