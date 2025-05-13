using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddPractice.Core.MoqExample.NotificationServiceExample
{
    public class NotificationService
    {
        private readonly IEmailSender _emailSender;
        public NotificationService(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public void NotifyUser(string userEmail)
        {
            if (string.IsNullOrWhiteSpace(userEmail)) 
                throw new ArgumentException("Email is required", nameof(userEmail));
            var subject = "Notification";
            var body = "Message";

            _emailSender.SendEmail(userEmail, subject, body);
        }
    }
}
