using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Entities;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.Rooms.Commands.CreateRoom;
public record CreateRoomCommand : IRequest<Room> 
{
    public string Name { get; init; } = null!;
    public int Money { get; init; } = 0!;
    public string ClientId { get; init; } = null!;
    public RoomState State { get; init; } = RoomState.closed;
    public RoomPersonnelSituation PersonnelSituation { get; init; } = RoomPersonnelSituation.not;
    public RoomPowerSupply PowerSupply { get; init; } = RoomPowerSupply.closed;
}

public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Room>
{
    private readonly IApplicationDbContext _context;

    public CreateRoomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Room> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        var entity = new Room();

        entity.Name = request.Name;

        entity.Money = request.Money;

        entity.ClientId = request.ClientId;

        entity.State = request.State;

        entity.PersonnelSituation = request.PersonnelSituation;

        entity.PowerSupply = request.PowerSupply;

        _context.Room.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }
}
