using OOP.Abstraction;
using OOP.DelegateAndEvent;
using OOP.DelegateAndEvent.FuncAndAction;
using OOP.DelegateAndEvent.Generics;
using OOP.Encapsulation;
using System;

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

            WorkWithGenerics();

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
        //Action и Func - универсальный встроенные делегаты - определенные типы, которые можно использоваться вместо собственных делегатов, если нгужна простая сигнатура
        //Action — метод, который ничего не возвращает
        //Func - метод, который возвращает значение
        //Predicate<T> - частный случай Func<T,bool>
        
        public static void WorkWithActionAndFunc()
        {
            Action<string> print = message => Console.WriteLine(message);  // аналогично делегату delegate void PrintDelegate(string message);
            print("Privet");

            Func<int, int, int> sum = (a, b) => a + b;    //У Func последний аргумент - это тип возвращаемого значения, остальные - входные

            Func<string> getMessage = () => "Privet";

            Func<string,int,bool> checkLenght = (text, len) => text.Length == len;

            Predicate<int> isEven = x => x %2 == 0;       //Частый случай Func всегда возвращает bool.
        }

        //Делегат      | Что делает                       | Сигнатура
        //Action<T>    | Метод без возвращаемого значения | void MyMethod(T)
        //Func<T, R>   | Метод с возвращаемым значением   | R MyMethod(T)
        //Predicate<T> | Проверка условия                 | bool MyMethod(T)

        //Ситуация                                    | Рекомендация
        //Простая сигнатура(1–3 параметра)            | Action, Func, Predicate
        //Явное семантическое имя важно(ClickHandler) | Собственный delegate
        //Будет использоваться в event                | Обычно создают именованный делегат
        //Метод возвращает void                       | Action<>
        //Метод возвращает результат                  | Func<>



        #endregion

        #region Generics
        //Обобщения позволяют написать класс/метод один раз, но использовать с разными типами
        //"Я пока не знаю, с каким типом буду работать, но ты мне его скажешь позже."
        //Можно ограничить типы.
        //where T : class. T должен быть ссылочным типом (string, object, List<T>, любой class)
        //where T : struct.  T должен быть значимым типом (int, double, DateTime, и т.д.)
        //where T : new(). T должен иметь публичный конструктор без параметров.
        //where T : SomeBaseClass. T должен быть наследником или самим классом
        //where T : interface. Т должен РЕАЛИЗОВЫВАТЬ интерфейс
        //Можно задавать множественные ограничения

        public static void WorkWithGenerics()
        {
            var intBox = new Box<int>(42);
            var stringBox = new Box<string>("Hi");
            intBox.Print();
            stringBox.Print();

            var processor = new Processor<int>( new List<int> {1,2,3,4,5});
            processor.ApplyAction(x => Console.Write(x*2));
            processor.Transform(x => x * 2);
            Console.WriteLine();
            processor.ApplyAction(Console.Write);
        }

        //Обобщенные методы можно делать не в обобщенном классе.
        //Сценарий                             | Обобщённый класс | Обобщённый метод
        //Один и тот же T нужен во всём классе | +                | 
        //Нужно однотипное хранилище(List<T>)  | +                | 
        //В классе обобщения не нужны          |                  | +
        //Метод работает с любыми типами       |                  | +

        #endregion

    }
}
