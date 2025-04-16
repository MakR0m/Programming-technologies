using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy.Payment
{
    internal class CashPayment : IPaymentStrategy
    {
        public void Pay(decimal amount)
        {
            Console.WriteLine("Процесс оплаты...");
            Console.WriteLine($"Сумма {amount} оплачена наличкой");
        }
    }
}
