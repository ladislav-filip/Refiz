namespace Refiz.Application.Entities.EntityList;

public class DataList<TItem>
{
    public long Count { get; }
    
    public IReadOnlyCollection<TItem> Items { get; }

    public DataList(long count, IEnumerable<TItem> items)
    {
        Count = count;
        Items = new List<TItem>(items);
    }

    public static DataList<TItem> CreateEmpty()
    {
        return new DataList<TItem>(0, Array.Empty<TItem>());
    }
}