using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter.Logger
{
    public class ExternalLogger
    {
        public void WriteLog(string message)       // Несовместим с ILogger (нет метода Log), класс закрыт для изменений
        {
            Console.WriteLine($"[EXTERNAL] {message}");
        }
    }
}
