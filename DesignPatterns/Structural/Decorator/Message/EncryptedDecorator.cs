using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.Message
{
    internal class EncryptedDecorator : MessageDecorator
    {
        public EncryptedDecorator(IMessage inner) : base(inner)
        {
        }

        public override string GetContent()
        {
            var content = _inner.GetContent();
            var encrypted = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(content));
            return encrypted;
        }
    }
}
