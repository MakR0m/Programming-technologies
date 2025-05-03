using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Interpreter.ArithmeticExpressions
{
    internal class Add : IExpression
    {
        private IExpression _left, _right;

        public Add(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret() => _left.Interpret() + _right.Interpret();
    }
}
