#region Info

// FileName:    EntityLogonQuery.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

using Refiz.Domain.AggregatesModel.EntityAggregate;

namespace Refiz.Queries.Entities.Queries;

public class EntityLogonQuery : EfBaseQuery<Entity, int, EntityLogon, EntityLogonFilter>, IEntityLogonQuery
{
    public EntityLogonQuery(IRefizContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Entity> ApplyFilter(EntityLogonFilter filter, IQueryable<Entity> query)
    {
        query = query.Where(p => p.Email.Contains(filter.Email, StringComparison.OrdinalIgnoreCase));
        return query;
    }

    public async Task<EntityLogon?> Get(string email)
    {
        var filter = new EntityLogonFilter(email);
        var (count, entityLogons) = await Get(filter);
        return count == 0 ? null : entityLogons.First();
    }
}