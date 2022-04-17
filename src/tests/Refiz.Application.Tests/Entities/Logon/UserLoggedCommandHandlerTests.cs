#region Info
// FileName:    UserLoggedCommandHandlerTests.cs
// Author:      Ladislav Filip
// Created:     17.04.2022
#endregion

using Refiz.Application.Entities.Logon;
using Refiz.Queries.Entities.Models;
using Refiz.Queries.Entities.Queries;

namespace Refiz.Application.Tests.Entities.Logon;

public class UserLoggedCommandHandlerTests
{
    private const string AnyMail = "any@mail.cz";
    private const string Password = "password";
    
    [Fact]
    public async Task Handle_UnknownUser_UserLogonException()
    {
        var mock = new Mock<IEntityLogonQuery>();

        var sut = new UserLoggedCommandHandler(mock.Object, Helper.GetMapper());
        
        var func = () => sut.Handle(new UserLoggedCommand("not-exists@mail.cz", Password), CancellationToken.None);

        await func.Should().ThrowAsync<UserLogonException>();
    }
    
    [Fact]
    public async Task Handle_BadPassword_UserLogonException()
    {
        var mock = new Mock<IEntityLogonQuery>();
        mock.Setup(s => s.Get(AnyMail)).ReturnsAsync(new EntityLogon(1, AnyMail, "wrong"));

        var sut = new UserLoggedCommandHandler(mock.Object, Helper.GetMapper());
        
        var func = () => sut.Handle(new UserLoggedCommand(AnyMail, Password), CancellationToken.None);

        await func.Should().ThrowAsync<UserLogonException>();
    }

    [Fact]
    public async Task Handle_()
    {
        var mock = new Mock<IEntityLogonQuery>();
        mock.Setup(s => s.Get(AnyMail)).ReturnsAsync(new EntityLogon(1, AnyMail, Password));

        var sut = new UserLoggedCommandHandler(mock.Object, Helper.GetMapper());
        
        var result = await sut.Handle(new UserLoggedCommand(AnyMail, Password), CancellationToken.None);

        result.Should().NotBeNull();
    }
}