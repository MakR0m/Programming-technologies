using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod.MessageFabric
{
    internal interface IMessage
    {
        void Send(string text);
    }
}
