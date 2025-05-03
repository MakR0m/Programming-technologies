using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Mediator.Chat
{
    internal class ChatRoom : IChatMediator
    {
        private List<ChatUser> _users = new List<ChatUser>();
        public void Register (ChatUser user) => _users.Add(user);

        public void SendMessage(string message, ChatUser sender)
        {
            foreach (ChatUser user in _users)
            {
                if (user != sender)
                    user.Receive(message,sender.Name);
            }
        }
    }
}
