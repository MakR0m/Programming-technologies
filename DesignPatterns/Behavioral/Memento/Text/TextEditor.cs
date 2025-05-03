using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Memento.Text
{
    internal class TextEditor
    {
        public string Text { get; set; } = "";

        public TextMemento Save() => new TextMemento(Text);

        public void Restore(TextMemento memento)
        {
            Text = memento.State;
        }
    }
}
