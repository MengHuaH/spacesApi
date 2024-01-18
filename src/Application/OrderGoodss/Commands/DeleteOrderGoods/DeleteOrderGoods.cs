using spacesApi.Application.Common.Interfaces;

namespace spacesApi.Application.OrderGoodss.Commands.DeleteOrderGoods;

public record DeleteOrderGoodsCommand(int Id) : IRequest;

public class DeleteOrderGoodsCommandHandler : IRequestHandler<DeleteOrderGoodsCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteOrderGoodsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteOrderGoodsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.OrderGoods
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.OrderGoods.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
