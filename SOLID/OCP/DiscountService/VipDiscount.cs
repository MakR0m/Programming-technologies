using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.DiscountService
{
    internal class VipDiscount : IDiscountPolicy
    {
        public decimal GetDiscount() => 0.2m;
    }
}
