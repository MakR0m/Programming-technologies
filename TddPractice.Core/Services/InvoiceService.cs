using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddPractice.Core.Services
{
    public class InvoiceService
    {
        public decimal CalculateTotal(decimal[] itemPrices, decimal discountPercent)
        {
            if (itemPrices == null || itemPrices.Length == 0)
                throw new ArgumentOutOfRangeException(nameof(itemPrices), "Массив пуст");
            if (discountPercent < 0 || discountPercent > 100)
                throw new ArgumentOutOfRangeException(nameof(discountPercent), "Скидка должна быть больше 0");
            decimal total = 0;
            foreach (var item in itemPrices)
            {
                if (item < 0)
                    throw new ArgumentOutOfRangeException(nameof(itemPrices), "Все элементы массива должны быть положительными");
                total += item;
            }
            return Math.Round(total * (100 - discountPercent) / 100, 2, MidpointRounding.ToPositiveInfinity);
        }
    }
}
