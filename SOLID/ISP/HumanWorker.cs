﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.ISP
{
    internal class HumanWorker : IWorkable, IEatable
    {
        public void Eat() => Console.WriteLine("Ест");

        public void Work() => Console.WriteLine("Работает");
    }
}
