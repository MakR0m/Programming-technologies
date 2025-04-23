using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter.Logger
{
    public class LoggerAdapter : ILogger
    {
        private readonly ExternalLogger _externalLogger;

        public LoggerAdapter(ExternalLogger externalLogger)
        {
            _externalLogger = externalLogger;
        }

        public void Log(string message)
        {
            _externalLogger.WriteLog(message);
        }
    }
}
