using OOP.Abstraction;
using OOP.DelegateAndEvent;
using OOP.Encapsulation;

namespace OOP
{
    internal class Program
    {
    #region theory
        //ООП — это парадигма программирования, основанная на объектах, которые содержат данные(состояние) и методы(поведение).
        //Главная цель — организовать код так, чтобы он был модульным, расширяемым, переиспользуемым и поддерживаемым.


        //сновные принципы ООП
        //Инкапсуляция — сокрытие внутренней реализации объекта и предоставление доступа только через публичные методы и свойства.      
        //Наследование — возможность создавать новые классы на основе уже существующих, расширяя или переопределяя их функциональность.
        //Полиморфизм — способность использовать единый интерфейс для различных типов данных.
        //Абстракция — выделение главного, отвлечение от деталей реализации.

        // класс - описание шаблона обьекта
        // обьект класса - экземляр класса (конкртеный обьект, созданные на основе шаблона)
        // интерфейс - контракт: набор методов и свойств без реализации.
        // абстрактный класс - Базовый класс от которого нельзя создать экземпляр напрямую. Может содержать как реализованные методы, так и абстрактные
        // virtual/override - Механизм полиморфизма
        // private, public, protected, internal - модификаторы доступа

    #endregion


        static void Main(string[] args)
        {
            BankAccount bA = new BankAccount();
            Console.WriteLine(bA.ToString());
            bA.Deposit(200m);
            Console.WriteLine(bA.ToString());
            bA.Withdraw(150m);  // внести 150 единиц валюты в типе decimal. m - значит десимал. f - float. по умолчанию double и int
            Console.WriteLine(bA.ToString());

            Student student = new Student("5", "Igor", 14);
            Teacher teacher = new Teacher("Himiya","Victor",45);
            List<Person> people = new List<Person>() { student, teacher };
            PrintIntroduction(people);

            List<Shape> shapes = new List<Shape> { new Triange(10,5), new Rectangle(10,5), new Circle(10) };
            foreach (Shape shape in shapes)
            {
                shape.GetArea();
                shape.Draw();
            }



            WorkWithDelegate();

            WorkWithEvent();

        }

        public static void PrintIntroduction(List<Person> people)
        {
            foreach (Person person in people)
            {
                person.Introduce();
            }
        }
        #region Delegate

        // Делегат - ссылка на метод с опред сигнатурой. Можно выносить в отдельный файл. Это тип данных

        public static void WorkWithDelegate()
        {
            MyDelegate del = PrintMessage;
            del += PrintMessage1;
            del("privet");

            Operator op = new Operator(Plus);
            op += Minus;
            op += Multiply;
            int i = op(5, 5);

            Operator op2 = (int a, int b) => a / b;  // Анонимный метод
            int n = op2(10, 2);

        }

        public delegate void MyDelegate(string message);

        public static void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void PrintMessage1(string msg)
        {
            Console.WriteLine(msg);
        }

        public delegate int Operator(int a, int b);

        public static int Plus(int a, int b) => a + b;
        public static int Minus(int a, int b) => a - b;
        public static int Multiply(int a, int b) => a * b;

        #endregion

        #region Event

        // Событие - синт сахар вокруг делегатов, который обеспечивает: инкапсуляцию (подписчики не могу вызвать событие напрямую) и возможность подписки, отписки.

        public static void WorkWithEvent()
        {
            Counter counter = new Counter(15);
            counter.ThresholdReached += OnThresholdReached;
            counter.Add(10);
            counter.Add(15);
        }

        static void OnThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"Порог {e.Threshold} достигнут в {e.TimeReached}");
        }

        #endregion

        #region Action and Func



        #endregion

    }
}
