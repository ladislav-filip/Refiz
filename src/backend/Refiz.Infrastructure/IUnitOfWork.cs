#region Info

// FileName:    IUnitOfWork.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

namespace Refiz.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}