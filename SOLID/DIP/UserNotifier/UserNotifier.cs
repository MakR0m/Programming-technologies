using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP.UserNotifier
{
    internal class UserNotifier
    {
        private readonly INotifier _notifier;

        public UserNotifier(INotifier notifier)
        {
            _notifier = notifier;
        }

        public void Notify(string user)
        {
            _notifier.Send(user, "Добро пожаловать");
        }
    }
}
