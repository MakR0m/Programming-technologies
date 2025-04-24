using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.Message
{
    internal class HtmlDecorator : MessageDecorator
    {
        public HtmlDecorator(IMessage inner) : base(inner)
        {
        }
        public override string GetContent()
        {
            return $"<html><body>{_inner.GetContent()}<body></html>";
        }
    }
}
