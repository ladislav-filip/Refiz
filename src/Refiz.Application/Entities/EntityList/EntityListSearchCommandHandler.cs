using AutoMapper;
using Refiz.Queries.Entities.Queries;
using Refiz.Queries.Filters;

namespace Refiz.Application.Entities.EntityList;

public class EntityListSearchCommandHandler : IRequestHandler<EntityListSearchCommand, DataList<EntityListItemModel>>
{
    private IMapper Mapper { get; }
    
    private readonly IEntityListQuery _entityListQuery;

    public EntityListSearchCommandHandler(IEntityListQuery entityListQuery, IMapper mapper)
    {
        Mapper = mapper;
        _entityListQuery = entityListQuery;
    }
    public async Task<DataList<EntityListItemModel>> Handle(EntityListSearchCommand request, CancellationToken cancellationToken)
    {
        var filter = Mapper.Map<EntityFilter>(request);
        var (count, entityItemLists) = await _entityListQuery.Get(filter);
        return new DataList<EntityListItemModel>(count, Mapper.Map<IEnumerable<EntityListItemModel>>(entityItemLists));
    }
}