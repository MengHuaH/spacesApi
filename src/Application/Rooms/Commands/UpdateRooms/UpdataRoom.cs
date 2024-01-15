using spacesApi.Application.Common.Interfaces;

namespace spacesApi.Application.Rooms.Commands.UpdateRoom;

public record UpdateRoomCommand : IRequest
{
    public int Id { get; init; }

    public string? Name { get; init; }

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

        await _context.SaveChangesAsync(cancellationToken);

    }
}
