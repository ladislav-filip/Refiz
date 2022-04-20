#region Info
// FileName:    EntityMapper.cs
// Author:      Ladislav Filip
// Created:     17.04.2022
#endregion

using AutoMapper;
using Refiz.Application.Entities.EntityList;
using Refiz.Application.Entities.Logon;
using Refiz.Queries.Entities.Models;
using Refiz.Queries.Filters;

namespace Refiz.Application.Mapping;

public class EntityMapper : Profile
{
    public EntityMapper()
    {
        CreateMap<EntityLogon, UserLoggedModel>();

        CreateMap<EntityListSearchCommand, EntityFilter>();

        CreateMap<EntityItemList, EntityListItemModel>()
            .ForCtorParam(nameof(EntityListItemModel.DisplayName), opt => opt.MapFrom(src => src.Surname + " " + src.Name));
    }
}