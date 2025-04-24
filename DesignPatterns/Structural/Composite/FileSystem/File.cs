using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.FileSystem
{
    internal class File : IFileSystem
    {
        public string Name { get; }

        public File(string name)
        {
            Name = name;
        }

        public void Print(string indent = "")
        {
            Console.WriteLine($"{indent}- File: {Name}");
        }
    }
}
