using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy.ProductFilter
{
    internal interface IFilterStrategy
    {
        bool IsMatch(Product product);
    }
}
