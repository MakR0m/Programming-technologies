using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Iterator.Collection
{
    internal interface IIterator<T>
    {
        bool HasNext();
        T Next();
    }
}
