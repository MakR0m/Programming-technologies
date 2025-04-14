using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP.UserNotifier
{
    internal class EmailNotofier : INotifier
    {
        public void Send(string user, string message) => Console.WriteLine($"[Email] {user} -> {message}");
    }
}
