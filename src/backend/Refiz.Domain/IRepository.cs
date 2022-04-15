#region Info
// FileName:    IRepository.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

namespace Refiz.Domain;

public interface IRepository<T> where T : IAggregateRoot
{
    IUnitOfWork UnitOfWork { get; }
}