#region Info

// FileName:    IEntityLogonQuery.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

namespace Refiz.Queries.Entities.Queries;

public interface IEntityLogonQuery
{
    Task<EntityLogon?> Get(string email);
}