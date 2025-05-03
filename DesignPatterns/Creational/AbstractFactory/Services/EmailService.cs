using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Services
{
    internal class EmailService : IEmailService
    {
        public void SendEmail(string to, string message)
        {
            Console.WriteLine($"[PROD] Отправлено письмо на {to}: {message}");
        }
    }
}
