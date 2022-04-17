#region Info
// FileName:    Helper.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

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
        
        context.Set<Language>().AddRange(
            new Language { Id = 1, Code = "cs", Active = true }, 
            new Language { Id = 2, Code = "en", Active = true }, 
            new Language { Id = 3, Code = "sk", Active = false }
        );
        
        context.Set<Country>().AddRange(
            new Country { Id = 1, IdLanguage = 1, CountryCode = "cz" },
            new Country { Id = 2, IdLanguage = 2, CountryCode = "us" },
            new Country { Id = 3, IdLanguage = 3, CountryCode = "sk" }
        );

        context.Set<Entity>().AddRange(
            new Entity { Id = 1, SurnameEntity = "Nowak", Email = "nowak@mail.cz", City = "Ostrava", NameEntity = "Josef", Password = "heslo", Street = "Nádražní" },
            new Entity { Id = 2, SurnameEntity = "Richter", Email = "richter@mail.cz", City = "Praha", NameEntity = "Pavel", Password = "heslo", Street = "Patrice Lumumby 2198/56" },
            new Entity { Id = 3, SurnameEntity = "Blehová", Email = "blehova@mail.cz", City = "Brno", NameEntity = "Alena", Password = "heslo", Street = "Sokolovská 2116" },
            new Entity { Id = 4, SurnameEntity = "Barfus", Email = "barfus@mail.cz", City = "Olomouc", NameEntity = "Jan", Password = "heslo", Street = "V Zahradách 531" },
            new Entity { Id = 5, SurnameEntity = "Figar", Email = "figar@mail.cz", City = "Ostrava", NameEntity = "Alois", Password = "heslo", Street = "Havlíčkova 818/56" }
        );

        context.SaveChanges();
        
        return context;
    }
}