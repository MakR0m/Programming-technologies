using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod.MessageFabric
{
    internal class EmailMessage : IMessage
    {
        public void Send(string text) => Console.WriteLine($"email {text}");
    }
}
