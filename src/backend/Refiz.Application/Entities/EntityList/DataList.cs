namespace Refiz.Application.Entities.EntityList;

public class DataList<TItem>
{
    public long Count { get; }

    public int Limit { get; }

    public int Pages { get; }
    
    public IReadOnlyCollection<TItem> Items { get; }

    public DataList(long count, int limit, IEnumerable<TItem> items)
    {
        Count = count;
        Limit = limit;
        Pages = CalcPages();
        Items = new List<TItem>(items);
    }

    public static DataList<TItem> CreateEmpty()
    {
        return new DataList<TItem>(0, 0, Array.Empty<TItem>());
    }

    private int CalcPages()
    {
        if (Limit <= 0 || Count <= 0)
        {
            return 1;
        }

        var result = (decimal)Count / (decimal)Limit;
        return (int)Math.Ceiling(result);
    }
}