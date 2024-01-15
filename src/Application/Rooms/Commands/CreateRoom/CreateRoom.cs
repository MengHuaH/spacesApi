using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.Rooms.Commands.CreateRoom;
public record CreateRoomCommand(string Name) : IRequest<string>;

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, string>
{
    private readonly IApplicationDbContext _context;

    public CreateRoomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var entity = new Room();

        entity.Name = request.Name;

        _context.Room.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Name;
    }
}
