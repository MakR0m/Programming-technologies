using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Services
{
    internal class DevelopmentPaymentService : IPaymentService
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"[FAKE] Симуляция платежа: {amount}р");
        }
    }
}
