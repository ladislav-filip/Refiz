using System.Threading.Tasks;
using Refiz.Queries.Entities.Queries;
using Refiz.Queries.Filters;

namespace Refiz.Queries.Database.Tests.Entities.Queries;

public class LanguageListQueryTests
{
    [Fact]
    public async Task Get_All_CountThree()
    {
        var sut = new LanguageListQuery(Helper.CreateRefizContext(), Helper.GetMapper());

        var data = await sut.Get(new LanguageFilter());

        data.Count.Should().Be(3);
    }
    
    [Fact]
    public async Task Get_OnlyActive_CountTwo()
    {
        var sut = new LanguageListQuery(Helper.CreateRefizContext(), Helper.GetMapper());

        var data = await sut.Get(new LanguageFilter(Active: true));

        data.Count.Should().Be(2);
    }
}