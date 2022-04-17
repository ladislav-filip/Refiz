using Microsoft.EntityFrameworkCore;

namespace Refiz.Queries;

public abstract class EfBaseQuery<TEntity, TKey, TItem, TFilter> : IBaseQuery 
    where TEntity : DomainEntity<TKey>
    where TItem : RecordMarker
    where TFilter : Filter
{
    private IRefizContext Context { get; }
    private IMapper Mapper { get; }

    protected EfBaseQuery(IRefizContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    public async Task<RecordListMarker<TItem>> Get(TFilter filter)
    {
        var query = Context.Set<TEntity>().AsQueryable();
        query = ApplyFilter(filter, query);
        query = GetAsPaginnate(filter, query);
        var data = await Mapper.ProjectTo<TItem>(query).ToListAsync();
        return new RecordListMarker<TItem>(data.Count, data);
    }

    protected virtual IQueryable<TEntity> ApplyFilter(TFilter filter, IQueryable<TEntity> query)
    {
        return query;
    }
    
    private IQueryable<TEntity> GetAsPaginnate(Filter filter, IQueryable<TEntity> query)
    {

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