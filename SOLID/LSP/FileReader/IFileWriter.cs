using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LSP.FileReader
{
    internal interface IFileWriter : IFileReader
    {
        void Write(string data);
    }
}
