using AutoMapper;
using Refiz.Infrastructure;

namespace Refiz.Queries;

public abstract class EfBaseQuery<TData, TItem> : IBaseQuery where TData : RecordListMarker<TItem> where TItem : RecordMarker
{
    protected RefizContext Context { get; }
    public IMapper Mapper { get; }

    protected EfBaseQuery(RefizContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }
    
    public abstract Task<TData> Get();
}