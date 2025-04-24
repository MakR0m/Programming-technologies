using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.Message
{
    internal class SimpleMessage : IMessage
    {
        private readonly string _text;

        public SimpleMessage(string text)
        {
            _text = text;
        }

        public string GetContent() => _text;
    }
}
