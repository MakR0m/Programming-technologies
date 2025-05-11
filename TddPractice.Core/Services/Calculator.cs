using System.Reflection.Metadata.Ecma335;

namespace TddPractice.Core.Services
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;


        public int Divide(int numerator, int denominator)
        { 
            if (denominator == 0) 
             throw new DivideByZeroException("Denominator cannot be zero.");
            return numerator/denominator;
        }

        public int Subtract(int a, int b) => a - b;

        public decimal CalculateDiscountPrice(decimal price, int percent)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Цена не может быть отрицательной.");

            if (percent < 0 || percent > 100)
                throw new ArgumentOutOfRangeException(nameof(percent), "Скидка должна находиться в диапазоне от 0 до 100");

            return price * (100-percent)/ 100;
        }

        public decimal RoundToNearest(decimal value, int precision)
        {
            if (precision < 0)
                throw new ArgumentOutOfRangeException(nameof(precision),"Выбор количества знаков после запятой не может быть отрицательным");
            return Math.Round(value, precision, MidpointRounding.AwayFromZero);
        }

        public decimal CalculateInstallment(decimal totalAmount, int months)
        {
            if (totalAmount <= 0)
                throw new ArgumentOutOfRangeException(nameof(totalAmount), "Задолженность должна быть больше нуля");
            if (months <= 0)
                throw new ArgumentOutOfRangeException(nameof(months), "Количество месяцев должно быть больше нуля");

            return Math.Round(totalAmount/months,2, MidpointRounding.ToPositiveInfinity);
        }
    }
}
