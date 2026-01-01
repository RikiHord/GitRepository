namespace TestVigenerCipher
{
    [TestClass]
    public sealed class TestVigenerCipher
    {
        [TestMethod]
        public void Test_EncryptText()
        {
            VigenerСipher.VigenerСipher cipher = new VigenerСipher.VigenerСipher();
            string key = "KEY";
            string plaintext = "This is a secret text.";
            string expectedCiphertext = "DLGC MQ K WCMVCD XCHX.";
            string actualCiphertext = cipher.Encrypt(plaintext, key);

            Assert.AreEqual(expectedCiphertext, actualCiphertext);
        }

        [TestMethod]
        public void Test_DecryptText()
        {
            VigenerСipher.VigenerСipher cipher = new VigenerСipher.VigenerСipher();
            string key = "KEY";
            string ciphertext = "DLGC MQ K WCMVCD XCHX.";
            string expectedPlaintext = "THIS IS A SECRET TEXT.";
            string actualPlaintext = cipher.Decrypt(ciphertext, key);

            Assert.AreEqual(expectedPlaintext, actualPlaintext);
        }

        [TestMethod]
        public void Test_EncryptDecryptCycle()
        {
            VigenerСipher.VigenerСipher cipher = new VigenerСipher.VigenerСipher();
            string key = "KEY";
            string originalPlaintext = "ANOTHER TEST MESSAGE!";
            string ciphertext = cipher.Encrypt(originalPlaintext, key);
            string decryptedPlaintext = cipher.Decrypt(ciphertext, key);

            Assert.AreEqual(originalPlaintext.ToUpper(), decryptedPlaintext);
        }

        [TestMethod]
        public void Test_NonAlphabeticCharacters()
        {
            VigenerСipher.VigenerСipher cipher = new VigenerСipher.VigenerСipher();
            string key = "KEY";
            string plaintext = "1234! @#$% ^&*()";
            string expectedCiphertext = "1234! @#$% ^&*()";
            string actualCiphertext = cipher.Encrypt(plaintext, key);
            Assert.AreEqual(expectedCiphertext, actualCiphertext);
        }
    }
}
