using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddPractice.Core.MoqExample.SimpleOrderExample
{
    public class OrderService
    {
        private readonly IDiscountService _discountService;

        public OrderService(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public decimal CalculateFinalPrice(decimal basePrice, string customerId)
        {
            var discount = _discountService.GetDiscountForCustomer(customerId);
            return Math.Round(basePrice * (1 - discount), 2);
        }
    }
}
