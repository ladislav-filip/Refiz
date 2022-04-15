#region Info
// FileName:    EntityListQuery.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using Refiz.Infrastructure;
using Refiz.Queries.Entities.Models;

namespace Refiz.Queries.Entities.Queries;

public class EntityListQuery : EfBaseQuery<RecordListMarker<EntityItemList>, EntityItemList>
{
    public EntityListQuery(RefizContext context) : base(context)
    {
    }

    public override RecordListMarker<EntityItemList> Get()
    {
        var data = Context.Entities.OrderBy(o => o.Identity).Select(p => new EntityItemList(p.Identity, p.SurnameEntity, p.Email)).ToList();
        return new RecordListMarker<EntityItemList>(data.Count, data);
    }
}