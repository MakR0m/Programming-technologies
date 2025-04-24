using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Composite.GraphicGroups
{
    internal class GraphicGroup : IGraphic
    {
        private readonly List<IGraphic> _children = new List<IGraphic>();

        public void Add(IGraphic graphic) => _children.Add(graphic);

        public void Draw()
        {
            Console.WriteLine("Рисуем группу");
            foreach (var child in _children)
                child.Draw();
        }
    }
}
