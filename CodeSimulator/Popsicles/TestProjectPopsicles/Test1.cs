using Popsicles;

namespace TestProjectPopsicles
{
    [TestClass]
    public sealed class TestCalcPortion
    {
        [TestMethod]
        public void TestCalcPortion_GiveAway()
        {
            var result = CalcPotrion.GivePortionOrNot(3, 9);
            Assert.AreEqual("give away", result);
        }

        [TestMethod]
        public void TestCalcPortion_NotGiveAway()
        {
            var result = CalcPotrion.GivePortionOrNot(3, 10);
            Assert.AreEqual("eat them yourself", result);
        }

        [TestMethod]
        public void TestCalcPortion_SiblingsMustBeGreaterByZero()
        {
            var result = CalcPotrion.GivePortionOrNot(0, 10);
            Assert.AreEqual("Number of siblings must be greater than zero.", result);
        }

        [TestMethod]
        public void TestCalcPortion_IceCreamMustBeGreaterByZero()
        {
            var result = CalcPotrion.GivePortionOrNot(3, 0);
            Assert.AreEqual("Number of ice creams must be greater than zero.", result);
        }
    }
}
