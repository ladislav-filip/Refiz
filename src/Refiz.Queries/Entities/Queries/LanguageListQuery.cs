#region Info

// FileName:    LanguageListQuery.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

namespace Refiz.Queries.Entities.Queries;

public class LanguageListQuery : EfBaseQuery<Language, LanguageItem, LanguageFilter>
{
    public LanguageListQuery(RefizContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Language> ApplyFilter(LanguageFilter filter, IQueryable<Language> query)
    {
        var (active, _, _) = filter;
        if (active != null)
        {
            query = query.Where(p => p.Active == active);
        }

        return query;
    }
}