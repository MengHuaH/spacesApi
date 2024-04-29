using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.Rooms.Commands.UpdateRoom;

public record UpdateRoomCommand : IRequest
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public int Money { get; init; } = 0!;
    public string ClientId { get; init; } = null!;
    public RoomState State { get; init; } = RoomState.closed;
    public RoomPersonnelSituation PersonnelSituation { get; init; } = RoomPersonnelSituation.not;
    public RoomPowerSupply PowerSupply { get; init; } = RoomPowerSupply.closed;

}

public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateRoomCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Room
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name;

        entity.Money = request.Money;

        entity.ClientId = request.ClientId;

        entity.State = request.State;

        entity.PersonnelSituation = request.PersonnelSituation;

        entity.PowerSupply = request.PowerSupply;

        await _context.SaveChangesAsync(cancellationToken);

    }
}
