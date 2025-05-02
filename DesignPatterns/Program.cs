using DesignPatterns.Behavioral.Command.Light;
using DesignPatterns.Behavioral.Observer.EventHandlerObserver;
using DesignPatterns.Behavioral.Observer.EventsObserver;
using DesignPatterns.Behavioral.Observer.ObserverWithoutEvents;
using DesignPatterns.Behavioral.Strategy.Payment;
using DesignPatterns.Behavioral.Strategy.ProductFilter;
using DesignPatterns.Creational.Builder.HttpRequest;
using DesignPatterns.Creational.Builder.UserExample;
using DesignPatterns.Creational.FactoryMethod.MessageFabric;
using DesignPatterns.Creational.Prototype;
using DesignPatterns.Creational.Prototype.TemplateForm;
using DesignPatterns.Creational.Singleton;
using DesignPatterns.Creational.Singleton.AppSettings_example_;
using DesignPatterns.Structural.Adapter.Logger;
using DesignPatterns.Structural.Bridge.Shape;
using DesignPatterns.Structural.Composite.FileSystem;
using DesignPatterns.Structural.Composite.GraphicGroups;
using DesignPatterns.Structural.Decorator.Message;
using DesignPatterns.Structural.Decorator.Stream;
using DesignPatterns.Structural.Facade.HomeTheaterFacade;
using System.Security.Cryptography.X509Certificates;

namespace DesignPatterns
{
    internal class Program
    {
        //Паттерны проектирования - это готовые решения типичных задач в архитектуре кода.
        //Паттерны - это подход/принцип как решать задачи гибко, понятно и масштабируемо
        //Классификация паттернов по Банде четырех:
        //Порождающие (Creational)   - как создавать объекты                     - Singleton, Factory, Builder
        //Структурные (Structural)    - как организовать отношения между классами - Adapter, Decorator, Composite
        //Поведенческие (Behavior)   - как управлять взаимодействием объектов    - Strategy, Observer, Command

        static void Main(string[] args)
        {
            var actions = new List<Action>() 
            {
                SingletonWork,
                FactoryMethodWork,
                BuilderWork,
                PrototypeWork,
                AdapterWork,
                BridgeWork,
                CompositeWork,
                DecoratorWork,
                FacadeWork,
                StrategyWork,
                ObserverWork,
                CommandWork
            };
            foreach (var action in actions)
            {
                action();
                Console.WriteLine(new string('_', 50));
            }
        }


        #region Порождающие

        #region Singleton
        //Обеспечивает, что у класса есть только один экземпляр, и предоставляет глобальную точку доступа к нему.
        //Пример, когда нужен только один обьект: логгер, конфигурация, кэш, подключение к б.д. и т.д.)
        //Когда глобальное состояние оправдано

        static void SingletonWork()
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

            var config1 = LazyAppSettings.Instance;
            Console.WriteLine(config1.DatabaseConnectionString);
            Console.WriteLine("Логирование включено? " + config1.EnableLogging);
        }



        #endregion

        #region Factory Method

        //Фабричный метод делегирует создание обьектов подклассам. Вместо нью используется метод-фабрика, который можно переопределить.
        //Изолирует создание обьектов, упрощает добавление новых типов, следуется принципу ОСР

        //Случай                                Strategy                         Factory
        //Я сам решаю, как объект себя ведёт	✅ отлично	                    ❌ неудобно(нужно лезть внутрь объекта)
        //Я хочу получать разные типы объектов	❌ Strategy не помогает	        ✅ Factory удобна для расширения
        //Я делаю расширяемый фреймворк	        🤝 часто используется внутри	✅ фабрики — основной способ подмены


        static void FactoryMethodWork()
        {
            MessageCreator creator = new EmailMessageCreator();
            var message = creator.CreateMessage();
            message.Send("Hello");
        }
        #endregion

        #region Builder
        //Builder позволяет пошагово создавать сложный обьект, отделяя процесс построения от самой структуры обьекта
        //Используется:
        //когда обьект имеет много параметров (в том числе необязательных),
        //когда нужно гибко настраиват обьект без длинного конструктора (более 10 аргументов).
        //когда нужно повторно использовать одну и ту же схему построения, но с разными конфигурациями.

        static void BuilderWork()
        {
            var user = new UserBuilder() //Плавный интерфейс. Цепочка вызовов, которая работает из-за return this.
                .SetName("Igor")
                .SetEmail("@mail")
                .SetAddress("Pushkina")
                .SetAge(10)
                .Build();
            Console.WriteLine(user.ToString());

            var request = new HttpRequestBuilder()
                .SetMethod("POST")
                .SetUrl("https://api.example.com/data")
                .AddHeader("Authorization", "Bearer TOKEN")
                .AddHeader("Content-Type", "application/json")
                .SetBody("{\"name\":\"test\"}")
                .Build();
            Console.WriteLine(request.ToString());

            var query = new SqlQueryBuilder()
                .Select("name", "email")
                .From("users")
                .Where("age > 18")
                .Where("is_active = 1")
                .OrderBy("name")
                .Build();

            Console.WriteLine(query);
        }


        #endregion

        #region Prototype

        //Prototype позволяет создавать копии обьектов без привязки к их конкретному классу, используя метод .Clone()
        //Используется когда создание нового обьекта слишком дорого (глубокая инициализация),
        //Когда нужно клонировать обьект с небольшими изменениями.
        //Когда нужно копировать структуру, но не использовать new напрямую
        static void PrototypeWork()
        {
            var original = new Report
            {
                Title = "Отчёт за май",
                Author = "Ирина",
                Pages = new() { "стр.1", "стр.2" }
            };

            var copy = original.Clone();
            copy.Title = "Копия отчёта";

            Console.WriteLine(original);
            Console.WriteLine(copy);


            var template = new TemplateForm
            {
                Title = "Заявление на отпуск",
                Fields = new List<FormField>
                {
                    new FormField { Label = "ФИО" },
                    new FormField { Label = "Даты отпуска" },
                    new FormField { Label = "Причина" }
                }
            };

            var form1 = template.Clone();                           //Создание новых обьектов на основе копии и изменения, чтобы не писать new.
            form1.Fields[0].Value = "Иван Петров";
            form1.Fields[1].Value = "01.06.2025 - 15.06.2025";      //Интерфейс нужен для того, чтобы быть увереным, что классы будут клонироваться, например для работы с дженериками.
            form1.Fields[2].Value = "По личным причинам";           //если нужен обобщенный метод, который точно должен работать с методом клон в любом типе, в котором он есть Where T : IPrototype<T>

            var form2 = template.Clone();
            form2.Fields[0].Value = "Анна Смирнова";
            form2.Fields[1].Value = "10.07.2025 - 24.07.2025";
            form2.Fields[2].Value = "Учебный отпуск";

            // Вывод
            template.Print(); // шаблон пустой — не испорчен
            form1.Print();    // заполненная форма Ивана
            form2.Print();    // заполненная форма Анны


        }

        #endregion

        #endregion

        #region Структурые

        #region Adapter

        // Адаптер позволяет обьектам с несовместимыми интерфейсами работать вместе, оборачивая один интерфейс в другой - без изменения исходного кода
        // "У меня есть объект, который делает нужное, но не так, как мне нужно. Я просто адаптирую его интерфейс."
        // Пример с переходником
        //Когда использовать: нельзя изменить сторонний код, клиент ждет нужный интефрейс, хочешь внедрить в систему чужой обьект

        static void AdapterWork()
        {
            ILogger logger = new LoggerAdapter(new ExternalLogger());     //Реализуем интерфейс в классе адаптер, а класс адаптер использует внешний класс.
            logger.Log("Приложение запущено");
        }

        #endregion

        #region Bridge
        //Мост разделяет абстракцию и реализацию, чтобы они могли развиваться независимо друг от друга
        //"Есть интерфейс и есть разные реализации - но нет необходимости жестко их связывать"
        //Паттерн позволяет гибко и независимо их комбинировать

        static void BridgeWork()
        {
            IRenderer vector = new VectorRenderer();    //Можно добавлять новые фигуры, можно добавлять новые способы отрисовки. Гибко и без дублирования
            Shape circle = new Structural.Bridge.Shape.Circle(vector, 5);
            circle.Draw();
                                                        //Просто использовать интерфейс - это инверсия зависимостей,
                                                        //а мост - это структура в которой абстракция содержит ссылку на реализацию и они развиваются независимо.
                                                        //В данном случае мост это поле типа интерфейса в абстрактном классе shape
            IRenderer raster = new RasterRenderer();
            Shape circle2 = new Structural.Bridge.Shape.Circle(raster, 10);
            circle2.Draw();
        }
        #endregion

        #region Composite (Компоновщик)
            //Позволяет обращаться к отдельным объектам и их композициям (деревьям) одинаково - через общий интерфейс.
            //Есть один элемент (например, кнопка). Есть контейнер, в котором могут быть другие кнопки, поля или даже другие контейнеры.
            //Компоновщик позволяет работать с ними как с одним и тем же типом.
            //Кнопка, лейбл, ТекстБокс в Панели. Файл и Папка. Иерархия сотрудников. (Дерево)
            //Элемент и группа реализуют один и тот же интерфейс, а клиентский код не отличает "лист" от "состава"
            //Используется когда иерархия объектов, когда нужно вложить объекты друг в друга, когда нужен единый интерфейс для элементов и контейнеров
        static void CompositeWork()
        {
            var circle = new Structural.Composite.GraphicGroups.Circle();
            var square = new Square();

            var group = new GraphicGroup();
            group.Add(circle);
            group.Add(square);
            
            var superGroup = new GraphicGroup();
            superGroup.Add(group);
            superGroup.Add(new Square());
            
            superGroup.Draw();

            var root = new Folder("Root");
            var docs = new Folder("Documents");
            var pics = new Folder("Pictures");

            docs.Add(new Structural.Composite.FileSystem.File("resume.docx"));
            docs.Add(new Structural.Composite.FileSystem.File("budget.xlsx"));

            pics.Add(new Structural.Composite.FileSystem.File("pic.png"));
            pics.Add(new Structural.Composite.FileSystem.File("pic.jpeg"));

            root.Add(docs);
            root.Add(pics);
            root.Add(new Structural.Composite.FileSystem.File("todo.txt"));
            root.Print();
        }

        #endregion

        #region Decorator

        //Позволяет добавлять объекту новое поведение на лету, не изменяя его класс и не создавая множество подклассов.
        //Вместо создания множества наследников создается обёртки вокруг объекта, каждая из которых расширяет его функциональность
        //При этом объект и его обёртки реализуют один и тот же интерфейс.
        //Гибкая и поэтапная обертка объектов

        static void DecoratorWork()
        {
            Structural.Decorator.Message.IMessage message = new SimpleMessage("Hello world");

            message = new HtmlDecorator(message);
            Console.WriteLine(message.GetContent());

            message = new EncryptedDecorator(message);
            Console.WriteLine(message.GetContent());

            Console.WriteLine();

            IStream stream = new Structural.Decorator.Stream.FileStream();
            stream = new CompressionStream(stream);     
            stream = new EncryptionStream(stream);      
            stream = new LoggingStream(stream);        
            stream.Write("Hello, world!");

        }

        #endregion

        #region Facade
        //Обеспечивает упрощенный интерфейс к сложно системе. Скрывает внутреннюю структуру, предоставляя единую точку входа для клиента
        //Есть множество сложных классов, настроек, зависимостей, но необходимо, чтобы пользователь работал только с одним удобным объектом
        // Нажимаешь одну кнопку на пульте, а за этим следует включение телевизора, настройка проектора, выключение света и запуск фильма.
        //Один RemoteControl обеспечивает доступ к множеству подсистем.

        // Используется когда: много компонентов, нет необходимости знать реализацию, необходимо облегчить использование системы, ограничить доступ к внутренним частям
        //Частный случай вью модели может выступать в роли фасада.
        static void FacadeWork()
        {
            var theater = new HomeTheaterFacade(new Projector(), new SoundSystem(), new Screen());
            theater.WatchMovie("Interstellar");
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

        static void StrategyWork()
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

        #region Observer
        //Позволяет объектам подписываться на события другого объекта и получать уведомления при его изменении
        //В MVVM - Subject(наблюдаемый) - ViewModel, реализующий INotifyPropertyChanged, Observers (наблюдатели) - элементы UI, подписанные через привязки.
        //В .NET события и делегаты реализуют Observer

        //| Когда использовать                | `Action<T>`    | `EventHandler<T>`      |
        //| --------------------------------- | -------------  | ---------------------- |
        //| Быстро, просто, без sender        | + Подходит     | - Не подходит          |
        //| Нужно указать, кто вызвал событие | - Нет sender   | + Есть sender          |
        //| Используешь UI / стандартные API  | - Не принято   | + Принято              |
        //| Хочешь единый подход для событий  | - Разрозненно  | + Принцип единообразия |


        static void ObserverWork()
        {
            //Просто действие
            var sensor = new TemperatureSensor();
            var app = new MobileApp();
            var logger = new TemperatureLogger();

            sensor.Attach(app);
            sensor.Attach(logger);

            sensor.SetTemperature(22.5f);
            sensor.SetTemperature(24.0f);
            //Event Action
            var sen = new AnotherTemperatureSensor();
            var ap = new AnotherMobileApp();
            var log = new AnotherTemperatureLogger();
            sen.TemperatureChanged += ap.OnTemperatureChanged;
            sen.TemperatureChanged += log.OnTemperatureChanged;
            sen.SetTemperature(21.5f);
            sen.SetTemperature(21.0f);

            //EventHandler и EventArgs
            var account = new BankAccount();
            var notifier = new BalanceNotifier();
            account.BalanceChanged += notifier.OnBalanceChanged;
            account.Deposit(100);

        }
        #endregion

        #region Command
        //Преобразует действие (запрос) в объект, позволяя: ставить в очередь, отменять, логировать и передавать как параметр.
        //Запрос - это объект, а не просто вызов метода
        //Основные участники:
        //Command - ICommand (интерфейс команды),
        //ConcreteCommand - CopyCommand, PasteCommand, PrintCommand,
        //Receiver - То, над чем выполняется действие (например, документ)
        //Invoker - Объект, который вызывает команды (например, кнопка)
        //Client - Конфигурирует команды и вызывает Invoker.Execute()
        //Применение: интерфейс ICommand (для команд MVVM), очереди задач (TaskQueue), макрокоманды, отложенные действия, отмена (Undo)

        static void CommandWork()
        {
            var light = new Light();
            var turnOn = new TurnOnCommand(light);
            var turnOff = new TurnOffCommand(light);
            var remote = new RemoteControl();
            remote.SetCommand(turnOn);
            remote.Undo();

            remote.SetCommand(turnOff);
            remote.Undo();
        }

        #endregion

        #endregion
    }
}
