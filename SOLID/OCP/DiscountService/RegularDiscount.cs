using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.DiscountService
{
    internal class RegularDiscount : IDiscountPolicy
    {
        public decimal GetDiscount() => 0.1m;
    }
}
