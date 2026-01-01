using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenerСipher
{
    public class VigenerСipher
    {
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string Encrypt(string plaintext, string key)
        {
            StringBuilder ciphertext = new StringBuilder();
            key = key.ToUpper();
            int keyIndex = 0;
            foreach (char c in plaintext.ToUpper())
            {
                if (alphabet.Contains(c))
                {
                    int p = alphabet.IndexOf(c);
                    int k = alphabet.IndexOf(key[keyIndex % key.Length]);
                    int cIndex = (p + k) % alphabet.Length;
                    ciphertext.Append(alphabet[cIndex]);
                    keyIndex++;
                }
                else
                {
                    ciphertext.Append(c);
                }
            }
            return ciphertext.ToString();
        }

        public string Decrypt(string ciphertext, string key)
        {
            StringBuilder plaintext = new StringBuilder();
            key = key.ToUpper();
            int keyIndex = 0;
            foreach (char c in ciphertext.ToUpper())
            {
                if (alphabet.Contains(c))
                {
                    int cIndex = alphabet.IndexOf(c);
                    int k = alphabet.IndexOf(key[keyIndex % key.Length]);
                    int p = (cIndex - k + alphabet.Length) % alphabet.Length;
                    plaintext.Append(alphabet[p]);
                    keyIndex++;
                }
                else
                {
                    plaintext.Append(c);
                }
            }
            return plaintext.ToString();
        }
    }
}
