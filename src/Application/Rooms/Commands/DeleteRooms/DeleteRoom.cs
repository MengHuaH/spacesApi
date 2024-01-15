using spacesApi.Application.Common.Interfaces;

namespace spacesApi.Application.Rooms.Commands.DeleteRoom;

public record DeleteRoomCommand(int Id) : IRequest;

public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteRoomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Room
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Room.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
