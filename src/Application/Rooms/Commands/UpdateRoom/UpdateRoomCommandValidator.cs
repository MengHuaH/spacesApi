using System.Text.RegularExpressions;
using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.Rooms.Commands.UpdateRoom;

public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateRoomCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v)
            .NotEmpty()
            .MustAsync(BeUniqueName)
                .WithMessage("房间名称已存在！")
                .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniqueName(UpdateRoomCommand updateRoomCommand, CancellationToken cancellationToken)
    {
        return await _context.Room.AnyAsync(x => x.Id == updateRoomCommand.Id && x.Name == updateRoomCommand.Name)
            || await _context.Room.AllAsync(l => l.Name != updateRoomCommand.Name, cancellationToken);
    }
}
