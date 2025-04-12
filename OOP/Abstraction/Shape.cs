using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Abstraction
{
    internal abstract class Shape
    {
        // Пришло в голову только начало координат для отрисовки и цвет хранить

        //Когда выбрать interface?
        //Когда нет общей реализации(в моем случае её нет).
        //Когда хочешь, чтобы класс мог реализовывать несколько интерфейсов(множественное наследование).
        //Когда тип не требует общего состояния(например, координат или цвета).

        //Когда выбрать abstract class?
        //Когда предполагаешь общее поведение или общие данные(например, координаты, цвет, прозрачность, имя и т.п.).
        //Когда хочешь расширить архитектуру в будущем(например, добавить общие методы, логирование, сериализацию, общий рендеринг).
        public (double X, double Y) Position { get; protected set; }
        
        public virtual void MoveTo(double x, double y)
        {
            Console.WriteLine($"Соединяем {Position.X} {Position.Y} с {x}, {y}");
        }
        public virtual void Draw()
        {
            Console.WriteLine($"Фигура расположена в точке {Position.X} {Position.Y}");
        }

        public abstract double GetArea();
    }
}
