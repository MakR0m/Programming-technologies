using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod.MessageFabric
{
    internal class SmsMessage : IMessage
    {
        public void Send(string text) => Console.WriteLine($"sms: {text}");
    }
}
