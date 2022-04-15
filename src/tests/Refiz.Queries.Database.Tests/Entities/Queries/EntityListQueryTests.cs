#region Info
// FileName:    EntityListQueryTests.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using System.Threading.Tasks;
using Refiz.Queries.Entities.Queries;

namespace Refiz.Queries.Database.Tests.Entities.Queries;

public class EntityListQueryTests
{
    [Fact]
    public async Task Get()
    {
        var sut = new EntityListQuery(Helper.CreateRefizContext(), Helper.GetMapper());

        var data = await sut.Get();

        data.Count.Should().Be(1);
    }
}