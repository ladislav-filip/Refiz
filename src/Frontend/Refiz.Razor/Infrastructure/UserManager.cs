using System.Security.Authentication;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Refiz.Application.Entities.Logon;
using Refiz.Razor.Configuration;
using Throw;

namespace Refiz.Razor.Infrastructure;

public class UserManager : IUserManager
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IOptionsMonitor<UserManagerOption> _userManagerOption;

    public UserManager(IMediator mediator, IHttpContextAccessor contextAccessor, IOptionsMonitor<UserManagerOption> userManagerOption)
    {
        _mediator = mediator;
        _contextAccessor = contextAccessor;
        _userManagerOption = userManagerOption;
    }

    public async Task SignIn(string userName, string password)
    {
        // userName.Throw(() => throw new AuthenticationException())
        //     .IfNotEquals(_userManagerOption.CurrentValue.DevUsername);
        //
        // password.Throw(() => throw new AuthenticationException())
        //     .IfNotEquals(_userManagerOption.CurrentValue.DevPassword);

        var cmd = new UserLoggedCommand(userName, password);
        var userModel = await _mediator.Send(cmd);

        var identity = new ClaimsIdentity(GetUserClaims(userModel), CookieAuthenticationDefaults.AuthenticationScheme);
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

    private IEnumerable<Claim>? GetUserClaims(UserLoggedModel userModel)
    {
        var result = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, userModel.Id.ToString()),
            new(ClaimTypes.Name, userModel.Email)
        };
        return result;
    }
}