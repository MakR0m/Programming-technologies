using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.Message
{
    internal abstract class MessageDecorator:IMessage
    {
        protected IMessage _inner;

        protected MessageDecorator(IMessage inner)
        {
            _inner = inner;
        }

        public abstract string GetContent();
    }
}
