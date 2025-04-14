using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LSP.FileReader
{
    internal class ReadWriteFile : IFileWriter
    {
        public string Read() => "Чтение файла...";

        public void Write(string data) => Console.WriteLine($"Запись {data}");
    }
}
