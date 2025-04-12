using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Abstraction
{
    internal class Triange : Shape
    {
        public double Side { get; set; }
        public double Height { get; set; }

        public Triange(double side, double height)
        {
            Side = side;
            Height = height;
        }
        public override double GetArea() => 0.5 * Height * Side;  // 1/2 - целочисленное деление, результат будет 0

        public override void Draw()
        {
            Console.WriteLine("Нарисовали треугольник");
        }
    }
}
