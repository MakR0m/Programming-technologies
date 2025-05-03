using DesignPatterns.Creational.Builder.UserExample;

namespace DesignPatterns.Behavioral.Mediator.Chat
{
    internal class ChatUser
    {
        public string Name { get; }
        private IChatMediator _chat;

        public ChatUser(string name, IChatMediator chat)
        {
            Name = name;
            _chat = chat;
        }

        public void Send(string message)
        {
            Console.WriteLine($"[Отправка] {Name}: {message}");
            _chat.SendMessage(message, this);
        }

        public void Receive(string message, string from)
        {
            Console.WriteLine($"[Получено] {Name} <- {from}: {message}");
        }
    }
}