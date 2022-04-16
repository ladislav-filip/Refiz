#region Info

// FileName:    CountryListQuery.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

namespace Refiz.Queries.Entities.Queries;

public class CountryListQuery : EfBaseQuery<Country, int, CountryItem, Filter>
{
    public CountryListQuery(RefizContext context, IMapper mapper) : base(context, mapper)
    {
    }
}