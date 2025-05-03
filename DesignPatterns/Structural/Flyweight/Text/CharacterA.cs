using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Flyweight.Text
{
    internal class CharacterA : ICharacter
    {
        public void Draw(int x, int y)
        {
            Console.WriteLine($"Рисуем символ 'A' в координатах ({x}, {y})");
        }
    }
}
