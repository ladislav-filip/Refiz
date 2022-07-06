#region Info
// FileName:    Cipher.cs
// Author:      Ladislav Filip
// Created:     17.04.2022
#endregion

using System.Security.Cryptography;
using System.Text;

namespace Refiz.Application.Infrastructure;

public class Cipher : ICipher
{
    private readonly string _salt;
    
        private const int Keysize = 256;

        public Cipher(string salt)
        {
            _salt = salt;

            if (salt.Length != 16)
            {
                throw new ArgumentException(message: "Salt must by 16 chars lenght", paramName: nameof(salt));
            }
        }

        public string Encrypt(string plainText, string passPhrase)
        {
            var initVectorBytes = Encoding.UTF8.GetBytes(_salt);
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var password = new PasswordDeriveBytes(passPhrase, null);
            
            #pragma warning disable CS0618
            var keyBytes = password.GetBytes(Keysize / 8);
            var symmetricKey = new RijndaelManaged();
            #pragma warning restore CS0618
            
            symmetricKey.Mode = CipherMode.CBC;
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            var cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            
            return Convert.ToBase64String(cipherTextBytes);
        }

        public string Decrypt(string cipherText, string passPhrase)
        {
            var initVectorBytes = Encoding.ASCII.GetBytes(_salt);
            var cipherTextBytes = Convert.FromBase64String(cipherText);
            var password = new PasswordDeriveBytes(passPhrase, null);

            #pragma warning disable CS0618
            var keyBytes = password.GetBytes(Keysize / 8);
            var symmetricKey = new RijndaelManaged();
            #pragma warning restore CS0618
            
            symmetricKey.Mode = CipherMode.CBC;
            var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            
            using var memoryStream = new MemoryStream(cipherTextBytes);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            var plainTextBytes = new byte[cipherTextBytes.Length];
            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
}