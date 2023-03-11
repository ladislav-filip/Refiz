#region Info

// FileName:    Filter.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

namespace Refiz.Queries.Filters;

public class Filter
{
    public Filter() { }
    
    public int Limit { get; init; }
    
    public int Skip { get; init; }

    public int SkipRaw
    {
        get
        {
            return Limit > 0 && Skip > 0 ?  Limit * Skip : 0;
        }
    }
}