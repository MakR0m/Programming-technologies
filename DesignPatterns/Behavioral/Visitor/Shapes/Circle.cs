using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Visitor.Shapes
{
    internal class Circle : IShape
    {
        public double Radius { get; set; }
        
        public Circle(double radius) => Radius = radius;

        public void Accept(IShapeVisitor visitor)
        {
            visitor.VisitCircle(this);
        }
    }
}
