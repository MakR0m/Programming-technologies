using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LSP.FileReader
{
    internal class ReadOnlyFile : IFileReader
    {
        public string Read() => "Чтение файла...";
    }
}
