using DataService.Calculator;
using DataService.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalculatorUnitTests
{
    [TestClass]
    public class CalculatorUnitTests
    {    
        public Mock<IDiagnostics> IDiagnosticService;
        public Mock<ISimpleCalculator> ICalculatorService;
        SimpleCalculator _calculatorMock = new SimpleCalculator();
        int _Start = 3;
        int _Amount = 2;

        [TestMethod]
        public void Add_Two_Numbers()
        {
            int actualResult = _calculatorMock.Add(_Start, _Amount);
            int expectedResult = 5;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Add_Two_Numbers_One_Negative()
        {

            int expectedResult = -4;
            int actualResult = _calculatorMock.Add(_Start, -7);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Add_Two_Numbers_Both_Negative()
        {
            int expectedResult = -8;
            int actualResult = _calculatorMock.Add(-4, -4);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Subtract_Two_Numbers()
        {
            int Start = 5;
            int Amount = 3;
            int expectedResult = 2;
            int actualResult = _calculatorMock.Subtract(Start, Amount);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Subtract_Two_Numbers_One_Negative()
        {
            int Start = 5;
            int Amount = 3;
            int expectedResult = 2;
            int actualResult = _calculatorMock.Subtract(Start, Amount);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Subtract_Two_Numbers_Two_Negative()
        {
            int Start = 5;
            int Amount = 3;
            int expectedResult = 2;
            int actualResult = _calculatorMock.Subtract(Start, Amount);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Multiply_Two_Numbers()
        {
            int expectedResult = 6;
            int actualResult = _calculatorMock.Multiply(_Start, _Amount);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Multiply_Two_Numbers_One_Negative()
        {
            int expectedResult = -6;
            int actualResult = _calculatorMock.Multiply(_Start, -2);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Multiply_Two_Numbers_Both_Negative()
        {
            int Start = -5;
            int Amount = -3;
            int expectedResult = 15;
            int actualResult = _calculatorMock.Multiply(Start, Amount);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Divide_Two_Numbers()
        {
            int Start = 10;
            int Amount = 4;
            float expectedResult = 2.5F;
            float actualResult = _calculatorMock.Divide(Start, Amount);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Divide_Two_Numbers_One_Negative()
        {
            int Start = 10;
            int Amount = -4;
            float expectedResult = -2.5F;
            float actualResult = _calculatorMock.Divide(Start, Amount);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Divide_Two_Numbers_Both_Negative()
        {
            int Start = -10;
            int Amount = -4;
            float expectedResult = 2.5F;
            float actualResult = _calculatorMock.Divide(Start, Amount);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetFifthPrime()
        {
            
            var actualResult = _calculatorMock.GetPrimeNumber(5);

            Assert.AreEqual(13, actualResult);
        }

        // I know this one fails, I couldn't figure out how to get the mock interface to use
        // the same instance as the class, happy to discuss what I attempted and where I went wrong.
        [TestMethod]
        public void Add_Method_Calls_Debugger_Interface()
        {
            float actualResult = _calculatorMock.Add(_Start, _Amount);
            IDiagnosticService.Verify(m => m.LogToDebugger(actualResult, 1), Times.Once);
        }
    }
}
