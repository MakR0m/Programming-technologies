using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Light
{
    internal class RemoteControl
    {
        private ICommand _lastCommand;

        public void SetCommand(ICommand command)
        {
            _lastCommand = command;
            command.Execute();
        }

        public void Undo()
        {
            Console.WriteLine("[Пульт] Отмена действия");
            _lastCommand?.Undo();
        }
    }
}
