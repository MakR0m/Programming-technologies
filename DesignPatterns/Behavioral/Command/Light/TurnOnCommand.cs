using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Light
{
    internal class TurnOnCommand : ICommand
    {
        private readonly Light _light;
        public TurnOnCommand(Light light) => _light = light;

        public void Execute() => _light.TurnOn();

        public void Undo() => _light.TurnOff();
    }
}
