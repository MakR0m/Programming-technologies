using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.BADS.LSP
{
    internal class FileWriter
    {
        public virtual void Write(string data)
        {
            Console.WriteLine($"Пишем в файл: {data}");
        }
    }

    class ReadOnlyFileWriter : FileWriter
    {
        public override void Write(string data)
        {
            throw new InvalidOperationException("Файл доступен только для чтения");
        }
    }

    //Где то в коде:

    //void SaveData(FileWriter writer)
    //{
    //    writer.Write("важные данные");
    //}

    //В SaveData можно передать обьекта класса ReadOnlyFileWriter, приведенный к FileWriter, что вызовет ошибку при сохранении
}
