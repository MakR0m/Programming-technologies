using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Proxy.Logging
{
    internal class LoggingProxy : IService
    {
        private RealService? _realService;

        public void Request()
        {
            Console.WriteLine("[Logging] Запрос перехвачен");
            _realService ??= new RealService();
            _realService.Request();
        }
    }
}
