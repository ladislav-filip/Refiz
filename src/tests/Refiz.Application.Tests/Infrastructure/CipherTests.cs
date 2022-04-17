#region Info
// FileName:    CipherTests.cs
// Author:      Ladislav Filip
// Created:     17.04.2022
#endregion

using Refiz.Application.Infrastructure;

namespace Refiz.Application.Tests.Infrastructure;

public class CipherTests
{
    private const string Salt = "nj2as877-.ko89uh";
    private const string MyPhrase = "phrase";
    private const string PasswordHash = "R9ghZFp7RDAhgL99eAg2gg==";
    private const string Password = "MyPassword";
    
    [Fact]
    public void Encrypt_Password_Success()
    {
        var sut = new Cipher(Salt);

        var result = sut.Encrypt(Password, MyPhrase);

        result.Should().Be(PasswordHash);
    }
    
    [Fact]
    public void Decrypt_PasswordHash_Success()
    {
        var sut = new Cipher(Salt);

        var result = sut.Decrypt(PasswordHash, MyPhrase);

        result.Should().Be(Password);
    }
}