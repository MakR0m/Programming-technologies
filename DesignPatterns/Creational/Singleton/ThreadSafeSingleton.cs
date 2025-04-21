using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton
{
    internal class ThreadSafeSingleton               // В многопоточном коде, разные потоки могут одновременно увидеть, что инстанс пустой и создать обьект
    {
        private static readonly object _lock = new();
        private static ThreadSafeSingleton _instance;

        public ThreadSafeSingleton()
        {

        }

        public static ThreadSafeSingleton Instance
        {
            get
            {
                lock (_lock)                         //Все потоки проверяют lock (_lock) - только один может войти внутрь. Первый поток создает _instance, остальные ждут и получают экземпляр
                {                                    //Lock - ключевое слово, предназначенное для синхронизации потоков.
                    return _instance ??= new ThreadSafeSingleton();
                }
            }
        }

        public void SayHello() => Console.WriteLine("Это сказал потокобезопасный одиночка");
    }
}
