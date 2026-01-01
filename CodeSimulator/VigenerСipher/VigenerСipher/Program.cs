namespace VigenerСipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VigenerСipher cipher = new VigenerСipher();
            string key = "KEY";
            string plaintext = "THIS IS A SECRET TEXT";
            string ciphertext = cipher.Encrypt(plaintext, key);
            Console.WriteLine($"Ciphertext: {ciphertext}");
            string decryptedText = cipher.Decrypt(ciphertext, key);
            Console.WriteLine($"Decrypted Text: {decryptedText}");
        }
    }
}
