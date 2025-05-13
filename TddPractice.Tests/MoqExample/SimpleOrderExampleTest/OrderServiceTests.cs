using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddPractice.Core.MoqExample;
using TddPractice.Core.MoqExample.SimpleOrderExample;

namespace TddPractice.Tests.MoqExample.SimpleOrderExampleTest
{
    public class OrderServiceTests
    {
        [Fact]
        public void CalculateFinalPrice_UserDiscountFromService()
        {
            //Arrange
            var discountMock = new Mock<IDiscountService>(); //Создаем мок типа подменяемого объекта
            discountMock.Setup(d => d.GetDiscountForCustomer("123")).Returns(0.25m); //Вызываем метод объекта с передачей параметра и говорим, что должно вернуться 25%

            var service = new OrderService(discountMock.Object);  //Создаем тестируемый объект класса с передачей мока

            //Act
            var result = service.CalculateFinalPrice(200m, "123");

            //Assert 
            Assert.Equal(150m, result);
        }

        [Fact]
        public void CalculateFinalPrice_CallsDiscountServiceWithCorrectCustomerId()
        {
            //Arrange
            var discountMock = new Mock<IDiscountService>();
            discountMock.Setup(d => d.GetDiscountForCustomer(It.IsAny<string>())).Returns(0.1m); //It.IsAny<string>() - говорит моку возвращать 0.1m независимо от переданного айди

            var service = new OrderService(discountMock.Object);

            //Act
            var result = service.CalculateFinalPrice(100m, "ABC");

            //Assert 
            discountMock.Verify(d => d.GetDiscountForCustomer("ABC"), Times.Once()); //Verify(...) — проверяет, что метод был вызван с customerId "ABC123". Times.Once — строго один раз.

            //Verify проверяет поведение мока. Полезен, чтобы убедиться в взаимодействии между компонентами. Полезные варианты Verify
            // Проверить, что не вызывался:
            //discountMock.Verify(d => d.GetDiscountForCustomer(It.IsAny<string>()), Times.Never);
            // Проверить, что вызывался хотя бы 2 раза:
            //discountMock.Verify(d => d.GetDiscountForCustomer(It.IsAny<string>()), Times.AtLeast(2));
            // Проверить, что вызывался с любым customerId:
            //discountMock.Verify(d => d.GetDiscountForCustomer(It.IsAny<string>()), Times.Once);

        }
    }
}
