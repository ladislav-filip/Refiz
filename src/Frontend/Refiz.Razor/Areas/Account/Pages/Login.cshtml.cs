using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refiz.Razor.Infrastructure;

namespace Refiz.Razor.Areas.Account.Pages;

public class LoginModel : PageModel
{
    private readonly IUserManager _userManager;

    public class LoginRec
    {
        [Required]
        public string? UserName { get; init; }
        
        [Required, MinLength(3)]
        public string? Password { get; init; }
    }

    public LoginModel(IUserManager userManager)
    {
        _userManager = userManager;
    }
    
    [BindProperty] public LoginRec? Data { get; private set; }
    
    public async Task<IActionResult> OnPostAsync(LoginRec data)
    {
        if (!ModelState.IsValid)
        {
            ViewData["Err"] = "chyba";
            return Page();
        }

        await _userManager.SignIn(data.UserName!, data.Password!);
        return RedirectToPage("Index");
    }
}