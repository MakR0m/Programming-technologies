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
        public const double Pi = 3.14; //Лучше хранить в другом месте, например в файле.

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetArea() => Pi * Radius * Radius;

    }
}
