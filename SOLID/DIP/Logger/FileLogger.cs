using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP.Logger
{
    internal class FileLogger : ILogger
    {
        public void Log(string message) => Console.WriteLine($"[Файл] {message}");
    }
}
