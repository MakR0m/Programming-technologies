using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Abstraction
{
    internal class Circle : Shape
    {
        public double Radius {  get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea() => Math.PI * Radius * Radius;

        public override void Draw()
        {
            Console.WriteLine("Нарисовали круг");
        }

    }
}
