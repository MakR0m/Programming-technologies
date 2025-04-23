using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Adapter.Logger
{
    internal interface ILogger
    {
        void Log(string message);
    }
}
