using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.FactoryMethod.MessageFabric
{
    internal class SmsMessageCreator : MessageCreator
    {
        public override IMessage CreateMessage() => new SmsMessage();
    }
}
