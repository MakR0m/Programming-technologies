using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP.Logger
{
    internal class ReportService
    {
        private readonly ILogger _logger;

        public ReportService(ILogger logger)       // Внедрение зависимости
        {
            _logger = logger;
        }

        public void GenerateReport()
        {
            _logger.Log("Генерируем отчет");
        }

        //ReportService зависит от абстракции ILogger, а не от конкретного класса. Детали (FileLogger) внедряются снаружи
    }
}
