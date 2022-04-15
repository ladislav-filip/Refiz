#region Info
// FileName:    Helper.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Refiz.Domain;
using Refiz.Domain.AggregatesModel.EntityAggregate;
using Refiz.Infrastructure;
using Refiz.Queries.Mapping;

namespace Refiz.Queries.Database.Tests;

public static class Helper
{
    public static IMapper GetMapper()
    {
        var conf = new MapperConfiguration(cfg => cfg.AddMaps(typeof(CountryMapper).Assembly) );
        conf.AssertConfigurationIsValid();
        return new Mapper(conf);
    }
    
    public static RefizContext CreateRefizContext()
    {
        var options = new DbContextOptionsBuilder<RefizContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        
        var context = new RefizContext(options);
        context.Database.EnsureCreated();
        
        context.Languages.AddRange(
            new Language { Idlanguage = 1, Code = "cs", Active = true }, 
            new Language { Idlanguage = 2, Code = "en", Active = true }, 
            new Language { Idlanguage = 3, Code = "sk", Active = false }
        );
        
        context.Countries.AddRange(
            new Country { IdCountry = 1, Idlanguage = 1, CountryCode = "cz" },
            new Country { IdCountry = 2, Idlanguage = 2, CountryCode = "us" },
            new Country { IdCountry = 3, Idlanguage = 3, CountryCode = "sk" }
        );

        context.Entities.AddRange(
            new Entity { Identity = 1, SurnameEntity = "Nowak", Email = "nowak@mail.cz", City = "Ostrava", NameEntity = "Josef", Password = "heslo", Street = "Nádražní" }
        );

        context.SaveChanges();
        
        return context;
    }
}