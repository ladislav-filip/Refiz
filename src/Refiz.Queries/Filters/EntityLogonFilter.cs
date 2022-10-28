#region Info

// FileName:    EntityLogonFilter.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

namespace Refiz.Queries.Filters;

public class EntityLogonFilter : Filter
{
    public string Email { get; init; }
}