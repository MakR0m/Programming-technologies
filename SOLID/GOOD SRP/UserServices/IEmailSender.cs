using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GOOD_SRP.UserServices
{
    internal interface IEmailSender
    {
        void Send(string username, string v);
    }
}
