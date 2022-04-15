#region Info
// FileName:    EntityListQueryTests.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using Microsoft.EntityFrameworkCore;
using Refiz.Infrastructure;
using Refiz.Queries.Entities.Queries;

namespace Refiz.Queries.Database.Tests.Entities.Queries;

public class EntityListQueryTests
{
    [Fact]
    public void Get()
    {
        var sut = new EntityListQuery(Helper.CreateRefizContext());

        var data = sut.Get();

        data.Count.Should().Be(1);
    }
}