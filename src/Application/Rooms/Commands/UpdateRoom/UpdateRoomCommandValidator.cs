using System.Text.RegularExpressions;
using spacesApi.Application.Common.Interfaces;

namespace spacesApi.Application.Rooms.Commands.UpdateRoom;

public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateRoomCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .NotEmpty()
            .MustAsync(BeUniqueName)
                .WithMessage("房间名称已存在！")
                .WithErrorCode("Unique");
    }

    public async Task<bool> BeUniqueName(string? Name, CancellationToken cancellationToken)
    {
        return await _context.Room
            .AllAsync(l => l.Name != Name, cancellationToken);
    }
}
