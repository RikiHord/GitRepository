using ItsASign;

namespace TestItsASign
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Test_OnePalindrom()
        {
            List<string> signNames = new List<string>{
                "LEVEL",
                "WORLD",
                "TEST",
                "CODE"
            };
            Assert.IsTrue(CheckClass.CheckPalindrom(signNames));
        }

        [TestMethod]
        public void Test_NoPalindrom()
        {
            List<string> signNames = new List<string>{
                "HELLO",
                "WORLD",
                "TEST",
                "CODE"
            };
            Assert.IsFalse(CheckClass.CheckPalindrom(signNames));
        }

        [TestMethod]
        public void Test_AllPalindroms()
        {
            List<string> signNames = new List<string>{
                "RADAR",
                "LEVEL",
                "ROTOR",
                "CIVIC"
            };
            Assert.IsTrue(CheckClass.CheckPalindrom(signNames));
        }

        [TestMethod]
        public void Test_EmptyList()
        {
            List<string> signNames = new List<string>();
            Assert.IsFalse(CheckClass.CheckPalindrom(signNames));
        }
    }
}
