#region Info
// FileName:    EntityRepositoryTests.cs
// Author:      Ladislav Filip
// Created:     17.04.2022
#endregion

using System.Diagnostics;

namespace Refiz.Infrastructure.Repositories;

public class EntityRepositoryTests
{
    [Fact]
    public async Task? GetById_1_NotNull()
    {
        var sut = new EntityRepository(Helper.CreateRefizContext());

        var result = await sut.GetById(1);

        result.Should().NotBeNull();
    }
    
    [Fact]
    public async Task? GetById_1_EmailByNowak()
    {
        var sut = new EntityRepository(Helper.CreateRefizContext());

        var result = await sut.GetById(1);

        Debug.Assert(result != null, nameof(result) + " != null");
        result.Email.Should().Be("nowak@mail.cz");
    }
    
    [Fact]
    public async Task? GetById_1_CountryIsCz()
    {
        var sut = new EntityRepository(Helper.CreateRefizContext());

        var result = await sut.GetById(1);

        Debug.Assert(result != null, nameof(result) + " != null");
        result.Country.CountryCode.Should().Be("cz");
    }
    
    [Fact]
    public async Task? GetById_1_CountryAndRole()
    {
        var sut = new EntityRepository(Helper.CreateRefizContext());

        var result = await sut.GetById(1);

        Debug.Assert(result != null, nameof(result) + " != null");
        result.Country.CountryCode.Should().Be("cz");
        result.Role.NameRole.Should().Be("admin");
    }
}