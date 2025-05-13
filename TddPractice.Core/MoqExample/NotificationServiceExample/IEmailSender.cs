using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddPractice.Core.MoqExample.NotificationServiceExample
{
    public interface IEmailSender
    {
        void SendEmail(string to, string subject, string body);
    }
}
