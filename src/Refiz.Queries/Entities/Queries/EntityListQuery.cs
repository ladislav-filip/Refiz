#region Info
// FileName:    EntityListQuery.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using Refiz.Domain.AggregatesModel.EntityAggregate;

namespace Refiz.Queries.Entities.Queries;

public class EntityListQuery : EfBaseQuery<Entity, int, EntityItemList, Filter>
{
    public EntityListQuery(RefizContext context, IMapper mapper) : base(context, mapper)
    {
    }
}