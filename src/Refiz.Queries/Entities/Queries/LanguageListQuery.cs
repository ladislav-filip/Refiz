#region Info

// FileName:    LanguageListQuery.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

namespace Refiz.Queries.Entities.Queries;

public class LanguageListQuery : EfBaseQuery<Language, byte, LanguageItem, LanguageFilter>
{
    public LanguageListQuery(RefizContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Language> ApplyFilter(LanguageFilter filter, IQueryable<Language> query)
    {
        if (filter.Active != null)
        {
            query = query.Where(p => p.Active == filter.Active);
        }

        return query;
    }
}