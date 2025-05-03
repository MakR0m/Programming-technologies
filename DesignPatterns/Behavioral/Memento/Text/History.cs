using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Memento.Text
{
    internal class History
    {
        private Stack<TextMemento> _undoStack = new Stack<TextMemento>();

        public void Backup(TextMemento memento) => _undoStack.Push(memento);

        public TextMemento Undo() => _undoStack.Pop();
    }
}
