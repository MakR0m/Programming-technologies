using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility.Loggers
{
    internal class FileLogger : Logger
    {
        protected override void Write(string message)
        {
            Console.WriteLine($"[File] {message} (записано в файл)");
        }
        protected override bool CanHandle(LogLevel level) => level == LogLevel.Warning;
    }
}
