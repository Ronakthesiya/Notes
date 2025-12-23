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
    public static class CryptoService
    {
        private const int KeySize = 256;

        public static string GenerateKey()
        {
            string keyBase64 = "";

            using (Aes aes = Aes.Create())
            {
                aes.KeySize = KeySize;
                aes.GenerateKey();

                keyBase64 = Convert.ToBase64String(aes.Key);
            }

            return keyBase64;
        }



        public static string Encrypt(string plaintext, string key, out string IVKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.Zeros;
                aes.Key = Convert.FromBase64String(key);
                aes.GenerateIV();

                IVKey = Convert.ToBase64String(aes.IV);

                ICryptoTransform encryptor = aes.CreateEncryptor();

                byte[] inputText = Encoding.UTF8.GetBytes(plaintext);
                byte[] val = encryptor.TransformFinalBlock(inputText,0,inputText.Length);

                return Convert.ToBase64String(val);
            }
        }

        public static string Decrypt(string Cypertxt, string key, string IVKey)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Padding = PaddingMode.Zeros;
                aes.Key = Convert.FromBase64String(key);
                aes.IV = Convert.FromBase64String(IVKey);
                //aes.GenerateIV();

                ICryptoTransform decryptor = aes.CreateDecryptor();

                byte[] cyper = Convert.FromBase64String(Cypertxt);
                byte[] val = decryptor.TransformFinalBlock(cyper, 0, cyper.Length);

                return Encoding.UTF8.GetString(val);
            }
        }

        //private static byte[] DeriveKey(string passphrase, byte[] salt)
        //{
        //    using var pbkdf2 = new Rfc2898DeriveBytes(passphrase, salt, Iterations, HashAlgorithmName.SHA256);
        //    return pbkdf2.GetBytes(KeySize);
        //}

    }
}