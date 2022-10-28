#region Info

// FileName:    IRefizContext.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Refiz.Infrastructure;

public interface IRefizContext : IDisposable
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
}