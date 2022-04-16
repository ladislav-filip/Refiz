#region Info

// FileName:    EntityFilter.cs
// Author:      Ladislav Filip
// Created:     16.04.2022

#endregion

namespace Refiz.Queries.Filters;

public record EntityFilter(string? City = null, string? Email = null, int Limit = 0, int Skip = 0) : Filter;