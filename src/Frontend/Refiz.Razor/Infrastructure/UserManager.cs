using System.Security.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Refiz.Razor.Configuration;
using Throw;

namespace Refiz.Razor.Infrastructure;

public class UserManager : IUserManager
{
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IOptionsMonitor<UserManagerOption> _userManagerOption;

    public UserManager(IHttpContextAccessor contextAccessor, IOptionsMonitor<UserManagerOption> userManagerOption)
    {
        _contextAccessor = contextAccessor;
        _userManagerOption = userManagerOption;
    }

    public async Task SignIn(string userName, string password)
    {
        userName.Throw(() => throw new AuthenticationException())
            .IfNotEquals(_userManagerOption.CurrentValue.DevUsername);

        password.Throw(() => throw new AuthenticationException())
            .IfNotEquals(_userManagerOption.CurrentValue.DevPassword);
        
        var identity = new ClaimsIdentity(GetUserClaims(userName), CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        if (_contextAccessor.HttpContext != null)
        {
            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }

    public async Task SignOut()
    {
        if (_contextAccessor.HttpContext != null)
        {
            await _contextAccessor.HttpContext.SignOutAsync();
        }
    }

    private IEnumerable<Claim>? GetUserClaims(string userName)
    {
        var result = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, _userManagerOption.CurrentValue.DevUserId),
            new(ClaimTypes.Name, _userManagerOption.CurrentValue.DevUserFullName)
        };
        return result;
    }
}