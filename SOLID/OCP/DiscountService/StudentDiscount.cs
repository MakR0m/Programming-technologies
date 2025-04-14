using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.DiscountService
{
    internal class StudentDiscount : IDiscountPolicy
    {
        // Логика расчета скидки может быть сложной и значительно отличаться от логики расчета скидки других типов
        public decimal GetDiscount()
        {
            //Логика
            return 0.15m;
        }
    }
}
