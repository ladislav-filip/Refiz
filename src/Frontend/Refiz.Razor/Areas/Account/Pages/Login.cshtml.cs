using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refiz.Application.Entities.Logon;
using Refiz.Razor.Infrastructure;

namespace Refiz.Razor.Areas.Account.Pages;

public class LoginModel : PageModel
{
    private readonly IUserManager _userManager;
    private readonly ILogger<LoginModel> _logger;

    public class LoginRec
    {
        [Required, MinLength(3), EmailAddress]
        public string? UserName { get; init; }
        
        [Required]
        public string? Password { get; init; }
    }

    public LoginModel(IUserManager userManager, ILogger<LoginModel> logger)
    {
        _userManager = userManager;
        _logger = logger;
    }
    
    [BindProperty] public LoginRec? Data { get; private set; }
    
    public async Task<IActionResult> OnPostAsync(LoginRec data)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            await _userManager.SignIn(data.UserName!, data.Password!);
        }
        catch (AuthenticationException)
        {
            ModelState.AddModelError("account", ViewRes.Texts.ErrLoginFail);
            return Page();
        }
        catch (UserLogonException e)
        {
            _logger.LogError(e, "Fail sign on");
            ModelState.AddModelError("account", ViewRes.Texts.ErrLoginFail);
            return Page();
        }

        return RedirectToPage("Index");
    }
}