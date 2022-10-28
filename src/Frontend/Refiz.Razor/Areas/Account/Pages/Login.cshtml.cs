using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Refiz.Razor.Areas.Account.Pages;

public class LoginModel : PageModel
{
    public class LoginRec
    {
        [Required]
        public string? UserName { get; init; }
        
        [Required, MinLength(3)]
        public string? Password { get; init; }
    }
    
    [BindProperty] public LoginRec? Data { get; private set; }
}