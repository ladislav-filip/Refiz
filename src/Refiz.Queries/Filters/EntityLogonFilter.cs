#region Info

// FileName:    EntityLogonFilter.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

namespace Refiz.Queries.Filters;

public record EntityLogonFilter(string Email) : Filter;