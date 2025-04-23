using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Bridge.Shape
{
    internal abstract class Shape
    {
        protected IRenderer Renderer;        //абстракция внутри абстракции.
                                                
        protected Shape(IRenderer renderer)
        {
            Renderer = renderer;
        }

        public abstract void Draw();
    }
}
