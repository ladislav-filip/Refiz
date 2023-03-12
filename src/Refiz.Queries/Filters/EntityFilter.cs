#region Info

// FileName:    EntityFilter.cs
// Author:      Ladislav Filip
// Created:     16.04.2022

#endregion

namespace Refiz.Queries.Filters;

public class EntityFilter : Filter
{
    public string? Search { get; init; }
}