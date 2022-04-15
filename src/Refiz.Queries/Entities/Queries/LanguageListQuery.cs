#region Info

// FileName:    LanguageListQuery.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Refiz.Infrastructure;
using Refiz.Queries.Entities.Models;

namespace Refiz.Queries.Entities.Queries;

public class LanguageListQuery : EfBaseQuery<RecordListMarker<LanguageItem>, LanguageItem>
{
    public LanguageListQuery(RefizContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public override async Task<RecordListMarker<LanguageItem>> Get()
    {
        var query = Context.Languages.OrderBy(o => o.Code);
        var data = await Mapper.ProjectTo<LanguageItem>(query).ToListAsync();
        return new RecordListMarker<LanguageItem>(data.Count, data);
    }
}