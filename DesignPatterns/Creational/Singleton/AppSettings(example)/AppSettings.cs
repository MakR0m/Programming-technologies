using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton.AppSettings_example_
{
    public class AppSettings
    {
        private static AppSettings _instance;
        private static readonly object _lock = new object();

        public static AppSettings Instance
        {
            get 
            {
                lock (_lock)
                {
                    return _instance??= new AppSettings();   // Если поле пустое создать экземпляр, если нет то вернуть, который там лежит
                }
            }
        }

        public AppSettings()
        {
            DatabaseConnectionString = "Server=localhost;Database-myapp";
            EnableLogging = true;
            
        }


        //Настройки
        public string DatabaseConnectionString { get; private set; }
        public bool EnableLogging { get; private set; }

        //Метод изменения конфигурации
        public void SetConncetionString(string conncetionString)
        {
            DatabaseConnectionString = conncetionString;
        }

        public void EnableOrDisableLogging(bool enabled)
        {
            EnableLogging = enabled;
        }

    }
}
