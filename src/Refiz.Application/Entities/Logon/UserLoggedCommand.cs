#region Info
// FileName:    UserLoggedCommand.cs
// Author:      Ladislav Filip
// Created:     17.04.2022
#endregion

namespace Refiz.Application.Entities.Logon;

public class UserLoggedCommand : IRequest<UserLoggedModel>
{
    public string Password { get; }
    public string Email { get; }

    public UserLoggedCommand(string email, string password)
    {
        Password = password;
        Email = email;
    }
}