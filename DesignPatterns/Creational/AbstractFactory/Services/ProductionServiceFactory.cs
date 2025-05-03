using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Services
{
    internal class ProductionServiceFactory : IServiceFactory
    {
        public IEmailService CreateEmailService() => new EmailService();

        public IPaymentService CreatePaymentService() => new PaymentService();
    }
}
