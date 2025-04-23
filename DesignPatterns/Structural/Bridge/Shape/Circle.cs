using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Bridge.Shape
{
    internal class Circle : Shape
    {
        private float _radius;

        public Circle (IRenderer renderer, float radius) : base(renderer)
        {
            _radius = radius;
        }

        public override void Draw()
        {
            Renderer.RenderCircle(_radius);
        }
    }
}
