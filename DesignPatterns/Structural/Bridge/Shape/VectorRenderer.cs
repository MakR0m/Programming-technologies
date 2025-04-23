using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Bridge.Shape
{
    internal class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius) => Console.WriteLine($"Рисуем круг векторной графикой с радиусом {radius}");
    }
}
