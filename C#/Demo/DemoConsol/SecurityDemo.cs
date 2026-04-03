using System;
using System.Collections.Generic;
//using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsol
{
    /// <summary>
    /// this class have two type of security demo 
    /// AES
    /// RSA
    /// </summary>
    internal class SecurityDemo
    {
        public static void demo()
        {
            Console.WriteLine("AES Encryption : ");
            encryptDataWithAes(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("RSA Encryption : ");
            encryptDataWithRsa(Console.ReadLine());
        }
        
        /// <summary>
        /// method encrypt data with aes 
        /// </summary>
        /// <param name="data">data to encrypt</param>
        public static void encryptDataWithAes(dynamic data)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("temptemptemptemp");
                aes.IV = Encoding.UTF8.GetBytes("temptemptemptemp");

                ICryptoTransform cryptoTransform = aes.CreateEncryptor();
                byte[] encrypted = cryptoTransform.TransformFinalBlock(Encoding.UTF8.GetBytes(data), 0, data.Length);

                foreach (var val in encrypted)
                {
                    Console.Write(val);
                }
                Console.WriteLine();

                decryptDataWithAes(encrypted);
            }
        }

        /// <summary>
        /// method dencrypt data with aes 
        /// </summary>
        /// <param name="data">data to dencrypt</param>
        public static void decryptDataWithAes(dynamic data)
        {
            using(var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes("temptemptemptemp");
                aes.IV = Encoding.UTF8.GetBytes("temptemptemptemp");

                ICryptoTransform cryptoTransform = aes.CreateDecryptor();
                dynamic decrypted = cryptoTransform.TransformFinalBlock(data, 0, data.Length);

                Console.Write(Encoding.UTF8.GetString(decrypted));
            }
        }

        /// <summary>
        /// method encrypt data with rsa 
        /// </summary>
        /// <param name="data">data to encrypt</param>
        public static void encryptDataWithRsa(dynamic data)
        {
            using (var rsa = RSA.Create())
            {

                var encrypted = rsa.Encrypt(Encoding.UTF8.GetBytes(data), RSAEncryptionPadding.OaepSHA1);

                foreach (var val in encrypted)
                {
                    Console.Write(val);
                }
                Console.WriteLine();

                decryptDataWithRsa(encrypted, rsa.ExportRSAPrivateKey());
            }
        }

        /// <summary>
        /// method dencrypt data with rsa 
        /// </summary>
        /// <param name="data">data to dencrypt</param>
        public static void decryptDataWithRsa(dynamic data, byte[] privateKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportRSAPrivateKey(privateKey, out _);
                var decrypted = rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA1);

                Console.Write(Encoding.UTF8.GetString(decrypted));
            }
        }

    }
}
