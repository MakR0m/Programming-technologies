using DesignPatterns.Behavioral.Strategy.Payment;
using DesignPatterns.Behavioral.Strategy.ProductFilter;
using DesignPatterns.Creational.Singleton;
using DesignPatterns.Creational.Singleton.AppSettings_example_;

namespace DesignPatterns
{
    internal class Program
    {
        //Паттерны проектирования - это готовые решения типичных задач в архитектуре кода.
        //Паттерны - это подход/принцип как решать задачи гибко, понятно и масштабируемо
        //Классификация паттернов по Банде четырех:
        //Порождающие (Creational)   - как создавать оьбекты                     - Singleton, Factory, Builder
        //Структурные (Stuctural)    - как организовать отношения между классами - Adapter, Decorator, Composite
        //Поведенческие (Bahavior)   - как управлять взаимодействием обьектов    - Strategy, Observer, Command

        static void Main(string[] args)
        {
            WorkWithSingleton();

            Console.WriteLine(new string('_', 50));

            StrategyWork();
        }

        #region Порождающие

        #region Singleton
        //Обеспечивает, что у класса есть только один экземпляр, и предоставляет глобальную точку доступа к нему.
        //Пример, когда нужен только один обьект: логгер, конфигурация, кэш, подключение к б.д. и т.д.)
        //Когда глобальное состояние оправдано

        static void WorkWithSingleton()
        {
            Singleton.Instance.SayHello();
            ThreadSafeSingleton.Instance.SayHello();

            var config = AppSettings.Instance;

            Console.WriteLine(config.DatabaseConnectionString);
            Console.WriteLine("Логирование включено? " + config.EnableLogging);

            //Изменение конфигурации
            config.SetConncetionString("another connection string");
            config.EnableOrDisableLogging(false);

            // повторный вызов тотже обьект
            var again = AppSettings.Instance;
            Console.WriteLine(again.DatabaseConnectionString);
        }
        


        #endregion

        #endregion


        #region Поведенческие

        #region Strategy
        //Стратегия - это когда у тебя есть несколько разных вариантов сделать одно и то же, а какой из вариантов будет выбран известно только во время выполнения
        //Иерархия классов-реализаций интерфейса - это сложно, надо имена придумать, чтобы они логичным были и т.д.
        //А часто стратегия нужна только в одном месте просто выбрать что-то. Поэтому поумолчанию лучше делать простой вариант через делегаты.
        //Если этого мало, или такой выбор в нескольких местах происходит, то тогда уже переходить к иерархии

        //Strategy - подстановка поведения по интерфейсу
        //Позволяет динамически подменять алгоритм или поведение объекта во время выполнение, не изменяя его сам.
        //1. Есть общий интрфейс (стратегия). 2. Есть несколько реализаций (вариантов поведения). 3. Есть контекст, которому подставляем нужную стратегию
        //Используется когда у обьекта есть несколько вариантов поведения, чтобы не делать if else, switch, enum.
        //Когда поведение нужно менять не лету (сортировка, логирование, фильтрация)
        //Когда нужен чистый и расширяемый код, соответсующий OCP

        public static void StrategyWork()
        {
            PaymentProcessor processor = new PaymentProcessor();
            processor.SetStrategy(new CardPayment());
            processor.PaymentProcess(500);

            processor.SetStrategy(new CryptoPayment());
            processor.PaymentProcess(1000);

            var products = new List<Product>
            {
                new Product { ProductName = "Телефон", Category = "Электроника", Price = 25000 },
                new Product { ProductName = "Микроволновка", Category = "Бытовая техника", Price = 8000 },
                new Product { ProductName = "Наушники", Category = "Электроника", Price = 3000 },
            };

            var filter = new ProductFilter();

            // Стартегия через функцию (простое действие)

            var cheap = filter.Filter(products, p => p.Price < 10000);

            var category = filter.Filter(products, p => p.Category == "Электроника");
            Console.WriteLine("Дешевые");
            foreach (var product in cheap)
                Console.WriteLine(product);
            Console.WriteLine("Электроника");
            foreach (var product in category)
                Console.WriteLine(product);

            //Стратегия через интерфейс и классы (сложное действие)

            filter.SetStrategy(new CategoryFilter("Бытовая техника"));
            var secondCategory = filter.FilterWithInterfaces(products);
            
            Console.WriteLine("Бытовая техника");                     //Where ленивый оператор, он вызывается не выше, а в фориче. Для того, чтобы вызвать сразу можно .ToList();
            foreach (var product in secondCategory)                   //Если вызывать потом все вместе, то везде сработает последний сет фильтр
                Console.WriteLine(product);

            filter.SetStrategy(new PriceFilter(5000));
            var secondCheap = filter.FilterWithInterfaces(products);
            Console.WriteLine("Дешевые");
            foreach (var product in secondCheap)
                Console.WriteLine(product);



            //По сути тоже самое, но функция внутри класса фильтра


        }

        //Можно легкое добавлять новые стратегии, не трогая существующий код. Легко тестировать отдельные стратегии.
        //Там где сложная логика, как с оплатой, используем интерфейсы, там где простая как с фильтрацией - func, action
        //Если думаешь: "Тут логики столько, что в одну лямбду не влезет...", значит, лучше использовать интерфейс и выделенный класс.

        #endregion

        #endregion
    }
}
