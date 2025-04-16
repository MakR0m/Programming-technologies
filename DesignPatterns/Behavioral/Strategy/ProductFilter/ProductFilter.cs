using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy.ProductFilter
{
    internal class ProductFilter
    {
        #region WithInterfaces
        private IFilterStrategy _filterStrategy;

        public void SetStrategy(IFilterStrategy filterStrategy)
        { _filterStrategy = filterStrategy; }

        public IEnumerable<Product> FilterWithInterfaces(IEnumerable<Product> products)
        {
            return products.Where(p => _filterStrategy.IsMatch(p)).ToList();
        }
        #endregion

        public List<Product> Filter(List<Product> products, Func<Product, bool> predicate)
        {
            return products.Where(predicate).ToList();
        }
    }
}
