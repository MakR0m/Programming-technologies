using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.DiscountService
{
    internal class DiscountService
    {
        public decimal CalculateDiscount(IDiscountPolicy policy)
        {
            return policy.GetDiscount();
        }
    }
}
