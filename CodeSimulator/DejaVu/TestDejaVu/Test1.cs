using DejaVu;

namespace TestDejaVu
{
    [TestClass]
    public sealed class TestDejavu
    {
        [TestMethod]
        public void Test_UniqueText()
        {
            string result = DejaVuFunc.CheckDejaVu("abcdefg");
            Assert.AreEqual("Unique", result);
        }

        [TestMethod]
        public void Test_DejaVuText()
        {
            string result = DejaVuFunc.CheckDejaVu("hello");
            Assert.AreEqual("Deja Vu", result);
        }

        [TestMethod]
        public void Test_EmptyString()
        {
            string result = DejaVuFunc.CheckDejaVu("");
            Assert.AreEqual("Unique", result);
        }
    }
}
