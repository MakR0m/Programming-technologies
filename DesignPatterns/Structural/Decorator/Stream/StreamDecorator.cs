using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.Stream
{
    internal abstract class StreamDecorator : IStream
    {
        protected readonly IStream _inner;

        protected StreamDecorator(IStream inner)
        {
            _inner = inner;
        }

        public abstract void Write(string data);
    }
}
