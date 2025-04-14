using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.BADS.DIP
{
    internal class ReportService
    {
        private readonly FileLogger _logger = new FileLogger();

        public void GenerateReport()
        {
            _logger.Log("Генерируем отчет");
        }
    }

    internal class FileLogger
    {
        public void Log(string message) => Console.WriteLine($"[Файл] {message}");
    }

    //ReportService жестко зависит от FileLogger. Нельзя просто заменить логер (на ConsoleLogger, DatabaseLogger, MockLogger и т.п.)
    //Класс трудно тестировать и переиспользовать
}
