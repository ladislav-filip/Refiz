#region Info

// FileName:    EntityMapper.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

using Refiz.Domain.AggregatesModel.EntityAggregate;

namespace Refiz.Queries.Mapping;

public class EntityMapper : Profile
{
    public EntityMapper()
    {
        CreateMap<Entity, EntityItemList>()
            .ForCtorParam(nameof(EntityItemList.Id), opt => opt.MapFrom(src => src.Id))
            .ForCtorParam(nameof(EntityItemList.Surname),
                opt => opt.MapFrom(src => src.SurnameEntity))
            .ForCtorParam(nameof(EntityItemList.Name),
                opt => opt.MapFrom(src => src.NameEntity))
            ;

        CreateMap<Entity, EntityLogon>()
            .ForCtorParam(nameof(EntityItemList.Id), opt => opt.MapFrom(src => src.Id));
    }
}