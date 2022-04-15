#region Info

// FileName:    CountryListQuery.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Refiz.Infrastructure;
using Refiz.Queries.Entities.Models;

namespace Refiz.Queries.Entities.Queries;

public class CountryListQuery : EfBaseQuery<RecordListMarker<CountryItem>, CountryItem>
{
    public CountryListQuery(RefizContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public override async Task<RecordListMarker<CountryItem>> Get()
    {
        var data = await Context.Countries.OrderBy(o => o.CountryCode).ProjectTo<CountryItem>(Mapper.ConfigurationProvider).ToListAsync();
        return new RecordListMarker<CountryItem>(data.Count, data);
    }
}