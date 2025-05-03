using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Services
{
    internal class PaymentService : IPaymentService
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"[PROD] Обработан платёж: {amount}р");
        }
    }
}
