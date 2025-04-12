using OOP.Abstraction;
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

        }

        public static void PrintIntroduction(List<Person> people)
        {
            foreach (Person person in people)
            {
                person.Introduce();
            }
        }
    }
}
