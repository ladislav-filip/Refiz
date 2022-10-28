#region Info

// FileName:    IEntityListQuery.cs
// Author:      Ladislav Filip
// Created:     20.04.2022

#endregion

namespace Refiz.Queries.Entities.Queries;

public interface IEntityListQuery
{
    Task<RecordListMarker<EntityItemList>> Get(EntityFilter filter);
}