using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Services
{
    internal class DevelopmentServiceFactory : IServiceFactory
    {
        public IEmailService CreateEmailService() => new DevelopmentEmailService();

        public IPaymentService CreatePaymentService() => new DevelopmentPaymentService();
    }
}
