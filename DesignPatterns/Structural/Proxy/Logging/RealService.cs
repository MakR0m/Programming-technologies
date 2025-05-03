using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Proxy.Logging
{
    internal class RealService : IService
    {
        public void Request()
        {
            Console.WriteLine("Выполняется запрос к реальному сервису");
        }
    }
}
