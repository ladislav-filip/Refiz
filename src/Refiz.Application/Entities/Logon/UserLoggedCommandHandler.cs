using AutoMapper;
using Refiz.Application.Infrastructure;
using Refiz.Queries.Entities.Queries;

namespace Refiz.Application.Entities.Logon;

public class UserLoggedCommandHandler : IRequestHandler<UserLoggedCommand, UserLoggedModel>
{
    private readonly IEntityLogonQuery _entityLogonQuery;
    private readonly ICipher _cipher;
    private readonly IMapper _mapper;

    public UserLoggedCommandHandler(IEntityLogonQuery entityLogonQuery, ICipher cipher, IMapper mapper)
    {
        _entityLogonQuery = entityLogonQuery;
        _cipher = cipher;
        _mapper = mapper;
    }
    
    public async Task<UserLoggedModel> Handle(UserLoggedCommand request, CancellationToken cancellationToken)
    {
        var entity = await _entityLogonQuery.Get(request.Email);

        if (entity == null)
        {
            throw new UserLogonException($"User with email '{request.Email}' not found");
        }

        var passwordHash = _cipher.Encrypt(request.Password, entity.Email);

        if (passwordHash != entity.Password)
        {
            throw new UserLogonException("User password is wrong");
        }

        return _mapper.Map<UserLoggedModel>(entity);
    }
}