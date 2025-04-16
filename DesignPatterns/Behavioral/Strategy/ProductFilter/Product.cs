using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatterns.Behavioral.Strategy.ProductFilter
{
    internal class Product
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public override string ToString() =>
        $"{ProductName} | {Category} | {Price} руб.";
    }
}
