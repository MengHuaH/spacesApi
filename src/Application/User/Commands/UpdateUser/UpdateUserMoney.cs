using spacesApi.Application.Common.Interfaces;

namespace spacesApi.Application.User.Commands.UpdateUserMoney;

public record UpdateUserMoneyCommand : IRequest
{
    public int Id { get; init; }
    public int Money { get; init; }

}

public class UpdateUserMoneyCommandHandler : IRequestHandler<UpdateUserMoneyCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateUserMoneyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateUserMoneyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.User
            .SingleAsync(b => b.Id == request.Id, cancellationToken);

        entity.Money = request.Money;

        await _context.SaveChangesAsync(cancellationToken);

    }
}
