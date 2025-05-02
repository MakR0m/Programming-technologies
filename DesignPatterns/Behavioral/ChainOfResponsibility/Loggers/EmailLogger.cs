using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility.Loggers
{
    internal class EmailLogger : Logger
    {
        protected override void Write(string message)
        {
            Console.WriteLine($"[Email] {message} (отправлено на почту)");
        }
        protected override bool CanHandle(LogLevel level) => level == LogLevel.Error;
    }
}
