using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Services
{
    internal class OrderProcessor
    {
        private readonly IEmailService _emailService;
        private readonly IPaymentService _paymentService;

        public OrderProcessor(IServiceFactory factory)
        {
            _emailService = factory.CreateEmailService();
            _paymentService = factory.CreatePaymentService();
        }

        public void ProcessOrder(string customer, decimal amount)
        {
            _paymentService.ProcessPayment(amount);
            _emailService.SendEmail(customer, "Заказ оплачен");
        }

    }
}
