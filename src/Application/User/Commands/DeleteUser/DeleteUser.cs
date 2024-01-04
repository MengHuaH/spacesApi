using spacesApi.Application.Common.Interfaces;

namespace spacesApi.Application.User.Commands.DeleteUser;

public record DeleteUserCommand(int Id) : IRequest;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.User
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.User.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
