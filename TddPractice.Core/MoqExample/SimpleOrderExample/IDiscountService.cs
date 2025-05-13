using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddPractice.Core.MoqExample.SimpleOrderExample
{
    public interface IDiscountService
    {
        decimal GetDiscountForCustomer(string customerId);
    }
}
