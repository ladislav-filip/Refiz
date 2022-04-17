#region Info
// FileName:    EntityRepository.cs
// Author:      Ladislav Filip
// Created:     17.04.2022
#endregion

using Refiz.Domain.AggregatesModel.EntityAggregate;

namespace Refiz.Infrastructure.Repositories;

public class EntityRepository : BaseRepository<Entity, int>, IEntityRepository
{
    public EntityRepository(RefizContext context) : base(context)
    {
    }
}