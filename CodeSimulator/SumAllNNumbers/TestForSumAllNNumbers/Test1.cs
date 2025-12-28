using SumAllNNumbers;
namespace TestForSumAllNNumbers
{
    [TestClass]
    public sealed class TestForInt
    {
        [TestMethod]
        public void Test_Int_NormalList()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = Calc<int>.CalcSumAllNNumbers(list, 2);
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Test_Int_EmptyList()
        {
            List<int> list = new List<int>() {};
            var result = Calc<int>.CalcSumAllNNumbers(list, 2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_Int_ErrorN()
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var result = Calc<int>.CalcSumAllNNumbers(list, -1);
            Assert.AreEqual(0, result);
        }
    }

    [TestClass]
    public sealed class TestForDouble
    {
        [TestMethod]
        public void Test_Double_NormalList()
        {
            List<double> list = new List<double>() { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 };
            var result = Calc<double>.CalcSumAllNNumbers(list, 2);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Test_Double_EmptyList()
        {
            List<double> list = new List<double>() { };
            var result = Calc<double>.CalcSumAllNNumbers(list, 2);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_Double_ErrorN()
        {
            List<double> list = new List<double>() { 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9 };
            var result = Calc<double>.CalcSumAllNNumbers(list, -1);
            Assert.AreEqual(0, result);
        }
    }
}
