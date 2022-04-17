#region Info

// FileName:    IBaseRepository.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

namespace Refiz.Domain.AggregatesModel.EntityAggregate;

public interface IBaseRepository<TEntity, in TKey>
    where TEntity : DomainEntity<TKey>
{
    Task<TEntity?> GetById(TKey id);

    void Insert(TEntity ent);

    void Update(TEntity ent);

    void Delete(TEntity ent);
}