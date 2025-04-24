using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.FileSystem
{
    internal interface IFileSystem
    {
        void Print(string indent = "");
    }
}
