using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Singleton.AppSettings_example_
{
    internal class LazyAppSettings
    {
        private static readonly Lazy<LazyAppSettings> _instance = new Lazy<LazyAppSettings>(Load); //Уже содержит логику лок и проверки наличия обьекта в _instance

        public static LazyAppSettings Instance => _instance.Value;

        public string DatabaseConnectionString { get; set; }
        public bool EnableLogging { get; set; }

        private static LazyAppSettings Load()
        {
            var json = File.ReadAllText("appsettings.json");
            return JsonSerializer.Deserialize<LazyAppSettings>(json);
        }
    }
}
