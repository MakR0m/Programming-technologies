﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.Services
{
    internal interface IEmailService
    {
        void SendEmail(string to, string message);
    }
}
