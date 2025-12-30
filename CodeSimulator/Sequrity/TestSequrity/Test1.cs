using Sequrity;

namespace TestSequrity
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Test_GuardBetweenMoneyAndThief()
        {
            string input = "xTxxxGxx$";
            bool result = CheckFloor.IsFloorSafe(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_NoGuardianAlarm()
        {
            string input = "xx$xxxxT";
            bool result = CheckFloor.IsFloorSafe(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_GuardMoneyAndThief()
        {
            string input = "xGxx$xxT";
            bool result = CheckFloor.IsFloorSafe(input);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Test_MultipleGuardsSafe()
        {
            string input = "xGxx$xxGxxT";
            bool result = CheckFloor.IsFloorSafe(input);
            Assert.IsTrue(result);
        }

    }

}
