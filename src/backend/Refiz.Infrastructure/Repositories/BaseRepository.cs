#region Info

// FileName:    BaseRepository.cs
// Author:      Ladislav Filip
// Created:     17.04.2022

#endregion

using System.Linq.Expressions;

namespace Refiz.Infrastructure.Repositories;

public abstract class BaseRepository<TEntity, TKey>
    where TEntity : DomainEntity<TKey>
{
    protected RefizContext Context { get; }

    protected BaseRepository(RefizContext context)
    {
        Context = context;
    }

    protected Task<TEntity?> GetByIdIntenal(TKey id, params Expression<Func<TEntity, object>>[]? includePaths)
    {
        var query = Context.Set<TEntity>().AsQueryable();

        if (includePaths is { Length: > 0 })
        {
            query = includePaths.Aggregate(query, (current, include) => current.Include(include));
        }
        
        var result = query.FirstOrDefaultAsync(p => p.Id != null && p.Id.Equals(id));
        return result;
    }

    public virtual Task<TEntity?> GetById(TKey id)
    {
        return GetByIdIntenal(id);
    }

    public virtual void Insert(TEntity ent)
    {
        Context.Set<TEntity>().Add(ent);
    }

    public virtual void Update(TEntity ent)
    {
        Context.Entry(ent).State = EntityState.Modified;
    }

    public virtual void Delete(TEntity ent)
    {
        Context.Set<TEntity>().Remove(ent);
    }
}