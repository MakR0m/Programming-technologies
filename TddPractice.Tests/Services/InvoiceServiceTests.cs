using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddPractice.Core.Services;

namespace TddPractice.Tests.Services
{
    public class InvoiceServiceTests
    {
        [Fact]
        public void CalculateTotal_ReturnsCorrectDiscountedSum()
        {
            //Arrange
            var service = new InvoiceService();
            decimal[] items = { 100m, 50m, 50m };
            decimal discount = 25;

            //Act
            decimal total = service.CalculateTotal(items, discount);

            //Assert
            Assert.Equal(150m, total);
        }

        public static IEnumerable<object[]> InvalidInvoiceData =>
            new List<object[]>
            {
                new object[] {null, 10, "itemPrices"},
                new object[] {new decimal[0],10, "itemPrices"},
                new object[] {new decimal[] {-10m,5m}, 10, "itemPrices" },
                new object[] {new decimal[] { 10m, 5m }, -5, "discountPercent" },
                new object[] {new decimal[] { 10m, 5m }, 120, "discountPercent" }
            };


        [Theory]
        [MemberData(nameof(InvalidInvoiceData))]
        public void CalculateTotal_ThrowException_OnInvalidInput(decimal[] items, decimal discount, string expectedParam)
        {
            //Arrange
            var service = new InvoiceService();

            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(()=> service.CalculateTotal(items, discount));

            //Assert
            Assert.Equal(expectedParam,exception.ParamName);
        }
    }
}
