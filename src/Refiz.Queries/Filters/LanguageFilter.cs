#region Info

// FileName:    LanguageFilter.cs
// Author:      Ladislav Filip
// Created:     16.04.2022

#endregion

namespace Refiz.Queries.Filters;

public record LanguageFilter(bool? Active = null, int Limit = 0, int Skip = 0) : Filter
{
    private readonly int _limit = Limit;
    private readonly int _skip = Skip;
}