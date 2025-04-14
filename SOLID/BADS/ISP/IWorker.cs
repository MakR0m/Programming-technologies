using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.BADS.ISP
{
    internal interface IWorker
    {
        void Work();
        void Eat();
    }

    public class HumanWorker : IWorker
    {
        public void Eat() => Console.WriteLine("Ест");

        public void Work() => Console.WriteLine("Работает");
    }

    class RobotWorker : IWorker
    {
        public void Eat() => throw new NotImplementedException(); // Не может есть
        
        public void Work() => Console.WriteLine("Ест");
    }

    //Интерфейс навязывает реализацию, нужно разделить на 2 интерфейса
}
