using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Visitor.Shapes
{
    internal class AreaCalculator : IShapeVisitor
    {
        public void VisitCircle(Circle circle)
        {
            double area = Math.PI * circle.Radius * circle.Radius;
            Console.WriteLine($"Площадь круга: {area:F2}");
        }

        public void VisitRectangle(Rectangle rect)
        {
            double area = rect.Width * rect.Height;
            Console.WriteLine($"Площадь прямоугольника: {area:F2}");
        }
    }
}
