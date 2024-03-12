using spacesApi.Application.Common.Interfaces;

namespace spacesApi.Application.User.Commands.UpdateUser;

public record UpdateUserCommand : IRequest
{
    public int Id { get; init; }

    public string Name { get; init; } = null!;
    public long PhoneNumber { get; init; }

}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.User
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.PhoneNumber = request.PhoneNumber;
        entity.Name = request.Name;

        await _context.SaveChangesAsync(cancellationToken);

    }
}
