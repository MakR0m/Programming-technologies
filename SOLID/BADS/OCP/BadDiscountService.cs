using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.BADS.OCP
{
    internal class BadDiscountService
    {
        public decimal GetDiscount(string customerType)
        {
            if (customerType == "Regular ") return 0.1m;
            else if (customerType == "VIP") return 0.2m;
            else if (customerType == "Student") return 0.15m;
            else return 0;
        }

        // При каждом добавлении нового типа клиента придется изменять метод GetDiscount
    }
}
