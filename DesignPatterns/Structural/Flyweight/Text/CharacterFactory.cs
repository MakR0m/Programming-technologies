using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Flyweight.Text
{
    internal class CharacterFactory
    {
        private Dictionary<char, ICharacter> _cache = new Dictionary<char, ICharacter>();
        public ICharacter GetCharacter(char symbol)
        {
            if(!_cache.ContainsKey(symbol))
            {
                if (symbol == 'A')
                    _cache[symbol] = new CharacterA();
                else
                    throw new NotSupportedException($"Символ '{symbol}' не поддерживается");
            }
            return _cache[symbol];
        }
    }
}
