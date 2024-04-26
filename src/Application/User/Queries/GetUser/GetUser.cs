using spacesApi.Application.Common.Interfaces;
using spacesApi.Application.Common.Models;
using spacesApi.Application.Common.Security;
using spacesApi.Domain.Entities;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.User.Queries.GetUser;

public record GetUserQuery : IRequest<Users>
{
    public long PhoneNumber { get; init; }

}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery,Users>
{
    private readonly IApplicationDbContext _context;

    public GetUserQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Users> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        Users users = new Users();
        bool iscc = await _context.User
            .AnyAsync(b => b.PhoneNumber == request.PhoneNumber);
        if (iscc)
        {
            users = await _context.User
            .SingleAsync(b => b.PhoneNumber == request.PhoneNumber);
        }
        return users;
    }
}
