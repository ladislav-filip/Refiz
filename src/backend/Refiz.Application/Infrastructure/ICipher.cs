#region Info

// FileName:    ICipher.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

namespace Refiz.Application.Infrastructure;

public interface ICipher
{
    string Encrypt(string plainText, string passPhrase);
    string Decrypt(string cipherText, string passPhrase);
}