using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.GraphicGroups
{
    internal class Circle : IGraphic
    {
        public void Draw() => Console.WriteLine("Draw a circle");
    }
}
