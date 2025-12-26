namespace TestNewDriveLicense
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestCalcTimeForGetNewLicense_InvalidName()
        {
            var calc = new NewDriversLicense.CalcTimeForGetNewLicense();
            int result = calc.CalculateTotalTime("", 2, "Alice Bob Charlie");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestCalcTimeForGetNewLicense_InvalidCountOfAgent()
        {
            var calc = new NewDriversLicense.CalcTimeForGetNewLicense();
            int result = calc.CalculateTotalTime("Katya", -1, "Alice Bob Charlie");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestCalcTimeForGetNewLicense_InvalidNamesOfPeople()
        {
            var calc = new NewDriversLicense.CalcTimeForGetNewLicense();
            int result = calc.CalculateTotalTime("Katya", 2, "");
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestCalcTimeForGetNewLicense_FirstInQueue()
        {
            var calc = new NewDriversLicense.CalcTimeForGetNewLicense();
            int result = calc.CalculateTotalTime("Alice", 2, "Bob Charlie David");
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestCalcTimeForGetNewLicense_LastInQueue()
        {
            var calc = new NewDriversLicense.CalcTimeForGetNewLicense();
            int result = calc.CalculateTotalTime("David", 1, "Alice Bob Charlie");
            Assert.AreEqual(80, result);
        }

        [TestMethod]
        public void TestCalcTimeForGetNewLicense_MiddleInQueue()
        {
            var calc = new NewDriversLicense.CalcTimeForGetNewLicense();
            int result = calc.CalculateTotalTime("Bob", 2, "Alice Charlie David");
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void TestCalcTimeForGetNewLicense_MultipleAgents()
        {
            var calc = new NewDriversLicense.CalcTimeForGetNewLicense();
            int result = calc.CalculateTotalTime("Charlie", 3, "Alice Bob David Eve Frank");
            Assert.AreEqual(20, result);
        }
    }
}
