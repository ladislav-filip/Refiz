#region Info

// FileName:    LanguageFilter.cs
// Author:      Ladislav Filip
// Created:     16.04.2022

#endregion

namespace Refiz.Queries.Filters;

public class LanguageFilter : Filter
{
    public bool? Active { get; init; }
}