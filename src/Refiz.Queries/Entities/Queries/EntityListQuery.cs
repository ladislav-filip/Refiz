#region Info
// FileName:    EntityListQuery.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using Refiz.Domain.AggregatesModel.EntityAggregate;

namespace Refiz.Queries.Entities.Queries;

public class EntityListQuery : EfBaseQuery<Entity, int, EntityItemList, EntityFilter>
{
    public EntityListQuery(RefizContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Entity> ApplyFilter(EntityFilter filter, IQueryable<Entity> query)
    {

        query = query.Where(p => p.Email.Contains(filter.Email));
        
        return query;
    }
}