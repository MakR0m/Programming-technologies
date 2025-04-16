using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy.Payment
{
    internal class PaymentProcessor
    {
        private IPaymentStrategy _paymentStrategy;

        public void SetStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void PaymentProcess(decimal amount)
        {
            _paymentStrategy.Pay(amount);
        }
    }
}
