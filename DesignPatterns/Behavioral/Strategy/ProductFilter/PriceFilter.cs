using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy.ProductFilter
{
    internal class PriceFilter : IFilterStrategy
    {
        private decimal _maxPrice;

        public PriceFilter(decimal maxPrice)
        {
            _maxPrice = maxPrice;
        }

        public bool IsMatch(Product product) => product.Price <= _maxPrice;
    }
}
