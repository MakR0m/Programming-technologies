using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.Stream
{
    internal class LoggingStream : StreamDecorator
    {
        public LoggingStream(IStream inner) : base(inner) { }

        public override void Write(string data)
        {
            Console.WriteLine($"[Лог] Пишем данные: {data}");
            _inner.Write(data);
        }
    }
}
