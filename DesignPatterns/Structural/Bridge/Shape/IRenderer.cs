using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Bridge.Shape
{
    internal interface IRenderer
    {
        void RenderCircle(float radius);
    }
}
