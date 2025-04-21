using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    public class Singleton                    //Простая реализация (ленивая, не потокобезопасная). Ленивая - создается при первом вызове
    {
        private static Singleton _instance;   // Экземпляр лежит в свойстве

        public Singleton()
        {
            
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Singleton();
                return _instance;
            }
        }

        public void SayHello() => Console.WriteLine("Это сказал одиночка");
    }
}
