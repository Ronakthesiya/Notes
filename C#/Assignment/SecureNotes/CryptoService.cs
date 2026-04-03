using SecureNotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace SecureNotes.Service
{
    /// <summary>
    /// Provide Crypto Services 
    /// Encryption and Decryption using AES
    /// </summary>
    public class CryptoService
    {
        private const int KeySize = 32;

        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[16];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }

        public byte[] GenerateKey(string passphrase, byte[] salt)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(passphrase,salt,100000,HashAlgorithmName.SHA256);

            return pbkdf2.GetBytes(KeySize);
        }


        public string Encrypt(string plaintext, byte[] key, out byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.Zeros;
                aes.Key = key;
                aes.GenerateIV();

                iv = aes.IV;

                ICryptoTransform encryptor = aes.CreateEncryptor();

                byte[] inputText = Encoding.UTF8.GetBytes(plaintext);
                byte[] val = encryptor.TransformFinalBlock(inputText,0,inputText.Length);

                return Convert.ToBase64String(val);
            }
        }


        public string Decrypt(string Cypertxt, byte[] key, byte[] iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.Zeros;
                aes.Key = key;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor();

                byte[] cyper = Convert.FromBase64String(Cypertxt);
                byte[] val = decryptor.TransformFinalBlock(cyper, 0, cyper.Length);

                return Encoding.UTF8.GetString(val);
            }
        }

  

    }
}