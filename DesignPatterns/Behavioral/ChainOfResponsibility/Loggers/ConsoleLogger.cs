using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility.Loggers
{
    internal class ConsoleLogger : Logger
    {
        protected override void Write(string message)
        {
            Console.WriteLine($"[Console] {message}");
        }
        protected override bool CanHandle(LogLevel level) => level == LogLevel.Info;

    }
}
