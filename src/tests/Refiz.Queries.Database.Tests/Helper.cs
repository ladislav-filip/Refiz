#region Info
// FileName:    Helper.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using Microsoft.EntityFrameworkCore;
using Refiz.Domain.AggregatesModel.EntityAggregate;
using Refiz.Infrastructure;

namespace Refiz.Queries.Database.Tests;

public static class Helper
{
    public static RefizContext CreateRefizContext()
    {
        var options = new DbContextOptionsBuilder<RefizContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;
        
        var context = new RefizContext(options);
        context.Database.EnsureCreated();
        
        context.Entities.AddRange(new []
        {
            new Entity { Identity = 1, SurnameEntity = "Nowak", Email = "nowak@mail.cz", City = "Ostrava", NameEntity = "Josef", Password = "heslo", Street = "Nádražní" }
        });

        context.SaveChanges();
        
        return context;
    }
}