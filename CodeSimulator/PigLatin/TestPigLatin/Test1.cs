namespace TestPigLatin
{
    [TestClass]
    public sealed class TestPigLatin
    {
        [TestMethod]
        public void Test_CommonText()
        {
            string input = "Hello world this is a test";
            string expected = "Ellohay orldway isthay isway away esttay";
            string actual = PigLatin.Converter.ToPigLatin(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_EmptyString()
        {
            string input = "";
            string expected = "";
            string actual = PigLatin.Converter.ToPigLatin(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SingleVowelWord()
        {
            string input = "apple";
            string expected = "appleway";
            string actual = PigLatin.Converter.ToPigLatin(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_SingleConsonantWord()
        {
            string input = "banana";
            string expected = "ananabay";
            string actual = PigLatin.Converter.ToPigLatin(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_OnlyA()
        {
            string input = "Aaaaaaa";
            string expected = "Aaaaaaaway";
            string actual = PigLatin.Converter.ToPigLatin(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
