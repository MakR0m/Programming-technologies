using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.Stream
{
    internal class CompressionStream : StreamDecorator
    {
        public CompressionStream(IStream inner) : base(inner) { }

        public override void Write(string data)
        {
            var compressed = $"[сжатый файл]";
            Console.WriteLine($"[Сжатие] {compressed}");
            _inner.Write(compressed);
        }
    }
}
