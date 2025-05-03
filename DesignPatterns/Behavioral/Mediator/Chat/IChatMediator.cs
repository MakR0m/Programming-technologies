using DesignPatterns.Creational.Builder.UserExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Mediator.Chat
{
    internal interface IChatMediator
    {
        void SendMessage(string message, ChatUser sender);
    }
}
