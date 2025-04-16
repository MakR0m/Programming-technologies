using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy.ProductFilter
{
    internal class CategoryFilter : IFilterStrategy
    {
        private string _category;

        public CategoryFilter(string category)
        {
            _category = category;
        }

        public bool IsMatch(Product product) => product.Category == _category;
    }
}
