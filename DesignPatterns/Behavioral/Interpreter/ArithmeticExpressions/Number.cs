using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Interpreter.ArithmeticExpressions
{
    internal class Number : IExpression
    {
        private int _value;
        public Number(int value) => _value = value;

        public int Interpret() => _value;
    }
}
