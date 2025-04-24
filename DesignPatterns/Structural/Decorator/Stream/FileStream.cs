using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.Stream
{
    internal class FileStream : IStream
    {
        public void Write(string data)
        {
            Console.WriteLine($"[Файл] Записано: {data}");
        }
    }
}
