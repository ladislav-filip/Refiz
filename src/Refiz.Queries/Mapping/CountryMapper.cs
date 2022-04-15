﻿#region Info

// FileName:    CountryMapper.cs
// Author:      Ladislav Filip
// Created:     15.04.2022

#endregion

using AutoMapper;
using Refiz.Domain;
using Refiz.Queries.Entities.Models;

namespace Refiz.Queries.Mapping;

public class CountryMapper : Profile
{
    public CountryMapper()
    {
        CreateMap<Country, CountryItem>()
            .ForCtorParam(nameof(CountryItem.Id), opt => opt.MapFrom(src => src.IdCountry))
            .ForCtorParam(nameof(CountryItem.Code), opt => opt.MapFrom(src => src.CountryCode));
    }
}