#region Info

// FileName:    IUnitOfWork.cs
// Author:      Ladislav Filip
// Created:     28.02.2022

#endregion

namespace Refiz.Domain;

public interface IUnitOfWork : IDisposable
{
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
}