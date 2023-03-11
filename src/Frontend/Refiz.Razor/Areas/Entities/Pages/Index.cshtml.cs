using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refiz.Application.Entities.EntityList;

namespace Refiz.Razor.Areas.Entities.Pages
{
    public class Index : PageModel
    {
        private readonly IMediator _mediator;

        public Index(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public DataList<EntityListItemModel>? Data { get; set; }
        
        public async Task<IActionResult> OnGetAsync(EntityListSearchCommand query)
        {
            Data = await _mediator.Send(query);
            return Page();
        }
    }
}