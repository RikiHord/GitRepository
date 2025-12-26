using Thats_Odd;

namespace TestProjectThatsOdd
{
    [TestClass]
    public sealed class Test1EvenSumCalculatorTests
    {
        [TestMethod]
        public void SumEvenNumbers_MixedNumbers_ReturnsEvenSum()
        {
            // Arrange
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            int result = EvenSumCalculator.SumEvenNumbers(numbers);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void SumEvenNumbers_OnlyOdd_ReturnsEvenSum()
        {
            // Arrange
            var numbers = new List<int> { 2, 4, 6};

            // Act
            int result = EvenSumCalculator.SumEvenNumbers(numbers);

            // Assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void SumEvenNumbers_NoOdd_ReturnsEvenSum()
        {
            // Arrange
            var numbers = new List<int> { 1, 3, 5 };

            // Act
            int result = EvenSumCalculator.SumEvenNumbers(numbers);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SumEvenNumbers_EmptyList_ReturnsEvenSum()
        {
            // Arrange
            var numbers = new List<int> {};

            // Act
            int result = EvenSumCalculator.SumEvenNumbers(numbers);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
