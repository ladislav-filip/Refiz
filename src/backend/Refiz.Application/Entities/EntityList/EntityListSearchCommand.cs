#region Info
// FileName:    EntityListSearchCommand.cs
// Author:      Ladislav Filip
// Created:     20.04.2022
#endregion

namespace Refiz.Application.Entities.EntityList;

public class EntityListSearchCommand : IRequest<DataList<EntityListItemModel>>
{
    public int Limit { get; init; }

    public int Skip { get; init; }

    public string? Search { get; init; }
}