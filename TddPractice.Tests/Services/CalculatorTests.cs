using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddPractice.Core.Services;

namespace TddPractice.Tests.Services
{
    public class CalculatorTests
    {
        //Тест - Запуск всех тестов

        //В случае с добавлением сначала написали метод, потом тест.
        [Fact]
        public void Add_ReturnsCorrectSum_WhenTwoIntegersProvided()
        {
            //Arrange
            var calculator = new Calculator();  //Подготовка данных
            //Act
            int result = calculator.Add(2, 3);  //Действие
            //Assert
            Assert.Equal(5, result);            //Проверка результата
        }

        //Вычитание через TDD: пишем тест, потом метод

        [Fact]
        public void Subtract_ReturnsCorrectDifference_WhenTwoIntegersProvided()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            int result = calculator.Subtract(5,3); // Тест не скомпилируется т.к. метода нет (RED), создали метод автоматом и отредактировали
            //Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Divide_ReturnsCorrectResult_WhenDenominatorIsNonZero()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            int result = calculator.Divide(10,2); 
            
            //Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ThrowsDivideByZeroException_WhenDenominatorIsZero()
        {
            //Arrange
            var calculator = new Calculator();

            //Act and Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0)); //Если исключение не обрабатывается, то тест упадет, но в случае с делением на 0 .Net сам выкидывает DivideByZeroException
        }

        #region CalculateDiscountPrice

        [Fact]
        public void CalculateDiscountPrice_ReturnsCorrectDiscountedPrice()
        {
            //Arrange
            var calculator = new Calculator();

            //Act 
            decimal result = calculator.CalculateDiscountPrice(200m, 25);

            //Assert
            Assert.Equal(150m, result);
        }

        [Fact]
        public void CalculateDiscountPrice_ThrowsException_WhenPriceIsNegative()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateDiscountPrice(-1m, 25));

            //Assert
            Assert.Equal("price", exception.ParamName);
        }

        [Fact]
        public void CalculateDiscountPrice_ThrowsException_WhenDiscountBelowZero()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateDiscountPrice(100m, -5));

            //Assert
            Assert.Equal("percent", exception.ParamName);
        }

        [Fact]
        public void CalculateDiscountPrice_ThrowsException_WhenDiscountAboveHundred()
        {
            //Arrange
            var calculator = new Calculator();

            //Act and Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateDiscountPrice(100m, 105));
        }

        #endregion

        #region RoundToNearest

        [Fact]
        public void RoundToNearest_ReturnsRoundedValue_WithPositivePrecision()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            decimal result = calculator.RoundToNearest(3.14159m, 2);
            //Assert
            Assert.Equal(3.14m, result);
        }

        [Fact]
        public void RoundToNearest_ThrowException_WhenPrecisionIsNegative()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.RoundToNearest(3.14159m, -2));
            //Assert
            Assert.Equal("precision", exception.ParamName);
        }

        [Fact]
        public void RoundToNearest_RoundsCorrectly_AtMidpoint()
        {
            var calculator = new Calculator();

            decimal result = calculator.RoundToNearest(2.345m, 2); // midpoint — 5

            Assert.Equal(2.35m, result); // away from zero
        }

        #endregion

        #region CalculateInstallment
        [Fact]
        public void CalculateInstallment_ReturnsRoundedMonthlyPayment()
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            decimal result = calculator.CalculateInstallment(1000m, 3);

            //Assert
            Assert.Equal(333.34m, result); // 1000 / 3 = 333.333..., округляем вверх

        }


        //Набор однотипных тестов

        [Theory]
        [InlineData(0,10,"totalAmount")]
        [InlineData(-10, 10,"totalAmount")]
        [InlineData(1000, 0, "months")]
        [InlineData(1000, -5, "months")]
        [InlineData(0, 0, "totalAmount")] // ожидается, что первое условие сработает
        public void CalculateInstallment_ThrowException_OnInvalidInput(decimal total, int months, string expectedParam)
        {
            //Arrange
            var calculator = new Calculator();
            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateInstallment(total, months));
            //Assert
            Assert.Equal(expectedParam, exception.ParamName);
        }

        #endregion




    }
}
