using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DIP.Logger
{
    internal interface ILogger
    {
        void Log(string message);
    }
}
