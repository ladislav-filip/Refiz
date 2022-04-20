#region Info
// FileName:    EntityListQueryTests.cs
// Author:      Ladislav Filip
// Created:     28.02.2022
#endregion

using Refiz.Queries.Entities.Queries;
using Refiz.Queries.Filters;

namespace Refiz.Queries.Database.Tests.Entities.Queries;

public class EntityListQueryTests
{
    [Fact]
    public async Task Get_All_CountFive()
    {
        var sut = new EntityListQuery(Helper.CreateRefizContext(), Helper.GetMapper());

        var data = await sut.Get(new EntityFilter{Email = "mail"});

        data.Count.Should().Be(5);
    }
    
    [Fact]
    public async Task Get_BlehovaEmailCaseInsensitive_Found()
    {
        var sut = new EntityListQuery(Helper.CreateRefizContext(), Helper.GetMapper());

        var data = await sut.Get(new EntityFilter{Email = "BLEHOVA"});

        data.Count.Should().Be(1);
    }

    [Fact]
    public async Task Get_Limit3_TotalCount5()
    {
        var sut = new EntityListQuery(Helper.CreateRefizContext(), Helper.GetMapper());

        var filter = new EntityFilter{Limit = 3};
        
        var data = await sut.Get(filter);

        data.Count.Should().Be(5);
        data.Data.Count().Should().Be(3);
    }
}