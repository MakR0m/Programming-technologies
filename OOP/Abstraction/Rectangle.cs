﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Abstraction
{
    internal class Rectangle : Shape
    {
        public double Width {  get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double GetArea() => Width * Height;

        public override void Draw()
        {
            Console.WriteLine("Нарисовали прямоугольник");
        }

    }
}
