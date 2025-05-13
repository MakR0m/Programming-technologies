using Castle.Core.Smtp;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddPractice.Core.MoqExample.NotificationServiceExample;
using IEmailSender = TddPractice.Core.MoqExample.NotificationServiceExample.IEmailSender;

namespace TddPractice.Tests.MoqExample.NotificationServiceExampleTest
{
    public class NotificationServiceTests
    {
        [Fact]
        public void NotifyUser_CallsEmailSender_WithCorrectArguments()
        {
            //Arrange
            var mockEmailSender = new Mock<IEmailSender>();
            var notificationService = new NotificationService(mockEmailSender.Object);

            //Act
            notificationService.NotifyUser("test@example.com");

            //Assert
            mockEmailSender.Verify(sender => sender.SendEmail("test@example.com", "Notification", "Message"),Times.Once);
        }

        [Fact]
        public void NotifyUser_ThrowsException_WhenEmailIsEmpty()
        {
            var mockEmailSender = new Mock<IEmailSender>();
            var service = new NotificationService(mockEmailSender.Object);

            Assert.Throws<ArgumentException>(() => service.NotifyUser(""));
            mockEmailSender.Verify(sender => sender.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never); //Метод мока не должен вызваться, т.к. service.NotifyUser("") должен выкинуть эксепшен
        }
    }
}
