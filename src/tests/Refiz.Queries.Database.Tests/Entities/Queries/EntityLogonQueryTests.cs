using System.Diagnostics;
using Refiz.Queries.Entities.Queries;

namespace Refiz.Queries.Database.Tests.Entities.Queries;

public class EntityLogonQueryTests
{
    [Fact]
    public async Task? Get_NotExistsUser_BeNull()
    {
        var sut = new EntityLogonQuery(Helper.CreateRefizContext(), Helper.GetMapper());

        var result = await sut.Get("no-exists@mail.cz");

        result.Should().BeNull();
    }
    
    [Fact]
    public async Task? Get_ExistsUser_BePassword()
    {
        var sut = new EntityLogonQuery(Helper.CreateRefizContext(), Helper.GetMapper());

        var result = await sut.Get("FigaR@mail.cz");

        Debug.Assert(result != null, nameof(result) + " != null");
        result.Password.Should().Be("password");
    }
}