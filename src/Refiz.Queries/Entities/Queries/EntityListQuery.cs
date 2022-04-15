#region Info
// FileName:    EntityListQuery.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using AutoMapper;
using Refiz.Domain.AggregatesModel.EntityAggregate;
using Refiz.Infrastructure;
using Refiz.Queries.Entities.Models;

namespace Refiz.Queries.Entities.Queries;

public class EntityListQuery : EfBaseQuery<Entity, EntityItemList, Filter>
{
    public EntityListQuery(RefizContext context, IMapper mapper) : base(context, mapper)
    {
    }
}