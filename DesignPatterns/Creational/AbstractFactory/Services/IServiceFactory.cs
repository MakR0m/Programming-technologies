using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Services
{
    internal interface IServiceFactory
    {
        IEmailService CreateEmailService();
        IPaymentService CreatePaymentService();
    }
}
