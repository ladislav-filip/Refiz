namespace Refiz.Razor.Infrastructure;

public interface IUserManager
{
    Task SignIn(string userName, string password);
    Task SignOut();
}