#region Info
// FileName:    Entities.cshtml.cs
// Author:      Ladislav Filip
// Created:     21.04.2022
#endregion

using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refiz.Application.Entities.EntityList;

namespace Refiz.Blazor.Pages;

public partial class Entities
{
    [Inject]
    private IMediator Mediator { get; set; }

    public string Title { get; private set; } = "Entities razor";

    public DataList<EntityListItemModel> Data { get; private set; } = DataList<EntityListItemModel>.CreateEmpty();
    

    // public Entities(IMediator mediator)
    // {
    //     _mediator = mediator;
    //     Title = "Entities razor";
    // }

    // protected override async Task OnInitializedAsync()
    // {
    //     var query = new EntityListSearchCommand();
    //     Data = await Mediator.Send(query);
    // }
}