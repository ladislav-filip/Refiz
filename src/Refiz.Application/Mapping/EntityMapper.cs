#region Info
// FileName:    EntityMapper.cs
// Author:      Ladislav Filip
// Created:     17.04.2022
#endregion

using AutoMapper;
using Refiz.Application.Entities.Logon;
using Refiz.Queries.Entities.Models;

namespace Refiz.Application.Mapping;

public class EntityMapper : Profile
{
    public EntityMapper()
    {
        CreateMap<EntityLogon, UserLoggedModel>();
    }
}