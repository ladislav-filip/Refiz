﻿using System.Threading.Tasks;
using Refiz.Queries.Entities.Queries;

namespace Refiz.Queries.Database.Tests.Entities.Queries;

public class CountryListQueryTests
{
    [Fact]
    public async Task Get()
    {
        var sut = new CountryListQuery(Helper.CreateRefizContext(), Helper.GetMapper());

        var data = await sut.Get(new Filter());

        data.Count.Should().Be(3);
    }
}