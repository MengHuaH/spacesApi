using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.User.Commands.CreateUser;
public record CreateUserCommand : IRequest<long>
{
    public long PhoneNumber { get; init; }

    public int Money { get; init; } = 0;
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
{
    private readonly IApplicationDbContext _context;

    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = new Users();

        entity.PhoneNumber = request.PhoneNumber;

        entity.Money = request.Money;

        _context.User.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.PhoneNumber;
    }
}
