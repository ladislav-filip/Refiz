#region Info
// FileName:    BaseQuery.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using Refiz.Infrastructure;

namespace Refiz.Queries;

public class BaseQuery : IBaseQuery
{
    protected readonly string _connectionString;

    protected BaseQuery(string connectionString)
    {
        _connectionString = connectionString;
    }
}

public record RecordMarker { }
public record RecordListMarker<T>(long Count, IEnumerable<T> Data) where T: RecordMarker { }



public abstract class EfBaseQuery<TData, TItem> : IBaseQuery where TData : RecordListMarker<TItem> where TItem : RecordMarker
{
    protected RefizContext Context { get; }

    protected EfBaseQuery(RefizContext context)
    {
        Context = context;
    }
    
    public abstract TData Get();
}