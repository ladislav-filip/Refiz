#region Info
// FileName:    EntityListSearchCommandHandlerTests.cs
// Author:      Ladislav Filip
// Created:     20.04.2022
#endregion

using Refiz.Application.Entities.EntityList;
using Refiz.Queries;
using Refiz.Queries.Entities.Models;
using Refiz.Queries.Entities.Queries;
using Refiz.Queries.Filters;

namespace Refiz.Application.Tests.Entities.EntityList;

public class EntityListSearchCommandHandlerTests
{
    [Fact]
    public async Task Handle_()
    {
        var mockQuery = new Mock<IEntityListQuery>();
        mockQuery.Setup(s => s.Get(It.IsAny<EntityFilter>())).ReturnsAsync(
            new RecordListMarker<EntityItemList>(2, new[]
            {
                new EntityItemList(1, "Nowak", "Jan", "nowak@mail.cz"),
                new EntityItemList(2, "Nowakova", "Alena", "nowakova@mail.cz")
            })
            );
        
        var sut = new EntityListSearchCommandHandler(mockQuery.Object, Helper.GetMapper());

        var result = await sut.Handle(new EntityListSearchCommand(), CancellationToken.None);

        result.Count.Should().Be(2);
    }
}