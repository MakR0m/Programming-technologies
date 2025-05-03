using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Services
{
    internal class DevelopmentEmailService : IEmailService
    {
        public void SendEmail(string to, string message)
        {
            Console.WriteLine($"[DEV] Email: {to} <- {message}");
        }
    }
}
