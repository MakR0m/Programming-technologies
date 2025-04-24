using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.Stream
{
    internal class EncryptionStream : StreamDecorator
    {
        public EncryptionStream(IStream inner) : base(inner) { }

        public override void Write(string data)
        {
            var encrypted = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(data));
            Console.WriteLine($"[Шифрование] Данные зашифрованы. Было: {data}; стало: {encrypted}");
            _inner.Write(encrypted);
        }
    }
}
