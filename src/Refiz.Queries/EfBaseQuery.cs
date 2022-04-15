using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Refiz.Infrastructure;

namespace Refiz.Queries;

public abstract class EfBaseQuery<TEntity, TItem, TFilter> : IBaseQuery 
    where TEntity : DomainEntity
    where TItem : RecordMarker
    where TFilter : Filter
{
    protected RefizContext Context { get; }
    protected IMapper Mapper { get; }

    protected EfBaseQuery(RefizContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    public virtual async Task<RecordListMarker<TItem>> Get(TFilter filter)
    {
        var query = GetAsPaginnate(filter);
        var data = await Mapper.ProjectTo<TItem>(query).ToListAsync();
        return new RecordListMarker<TItem>(data.Count, data);
    }
    
    protected IQueryable<TEntity> GetAsPaginnate(Filter filter)
    {
        var query = Context.Set<TEntity>().AsQueryable();
        
        if (filter.Limit > 0)
        {
            query = query.Take(filter.Limit);
        }

        if (filter.Skip > 0)
        {
            query = query.Skip(filter.Skip);
        }

        return query;
    }
}