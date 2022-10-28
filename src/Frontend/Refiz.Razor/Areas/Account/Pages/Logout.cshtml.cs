using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refiz.Razor.Infrastructure;

namespace Refiz.Razor.Areas.Account.Pages;

public class LogoutModel : PageModel
{
    private readonly IUserManager _userManager;

    public LogoutModel(IUserManager userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<IActionResult> OnGetAsync()
    {
        await _userManager.SignOut();
        return RedirectToPage("Index");
    }
}