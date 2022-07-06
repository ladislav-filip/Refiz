#region Info
// FileName:    Helper.cs
// Author:      Ladislav Filip
// Created:     17.04.2022
#endregion

using AutoMapper;
using Refiz.Application.Mapping;

namespace Refiz.Application.Tests;

public static class Helper
{
    public static IMapper GetMapper()
    {
        var conf = new MapperConfiguration(cfg => cfg.AddMaps(typeof(EntityMapper).Assembly) );
        conf.AssertConfigurationIsValid();
        return new Mapper(conf);
    }
}