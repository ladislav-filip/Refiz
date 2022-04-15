#region Info
// FileName:    EntityListQuery.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Refiz.Infrastructure;
using Refiz.Queries.Entities.Models;

namespace Refiz.Queries.Entities.Queries;

public class EntityListQuery : EfBaseQuery<RecordListMarker<EntityItemList>, EntityItemList>
{
    public EntityListQuery(RefizContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public override async Task<RecordListMarker<EntityItemList>> Get()
    {
        var data = await Context.Entities.OrderBy(o => o.Identity).ProjectTo<EntityItemList>(Mapper.ConfigurationProvider).ToListAsync();
        return new RecordListMarker<EntityItemList>(data.Count, data);
    }
}