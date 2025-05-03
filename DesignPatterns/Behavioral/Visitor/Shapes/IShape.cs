using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Visitor.Shapes
{
    internal interface IShape
    {
        void Accept (IShapeVisitor visitor);
    }
}
