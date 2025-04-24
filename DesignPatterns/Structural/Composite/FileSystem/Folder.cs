using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.FileSystem
{
    internal class Folder :  IFileSystem
    {
        public string Name { get; }
        private readonly List<IFileSystem> _items = new List<IFileSystem>();

        public Folder(string name)
        {
            Name = name;
        }

        public void Add(IFileSystem item) => _items.Add(item);

        public void Print(string indent = "")
        {
            Console.WriteLine($"{indent}+ Folder: {Name}");
            foreach (var item in _items)
                item.Print(indent+" ");
        }
    }
}
