#region Info
// FileName:    EntityListQueryTests.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using System.Threading.Tasks;
using Refiz.Queries.Entities.Queries;
using Refiz.Queries.Filters;

namespace Refiz.Queries.Database.Tests.Entities.Queries;

public class EntityListQueryTests
{
    [Fact]
    public async Task Get_All_CountFive()
    {
        var sut = new EntityListQuery(Helper.CreateRefizContext(), Helper.GetMapper());

        var data = await sut.Get(new Filter());

        data.Count.Should().Be(5);
    }
}