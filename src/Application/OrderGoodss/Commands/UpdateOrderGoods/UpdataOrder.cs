using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.OrderGoodss.Commands.UpdateOrder;

public record UpdateOrderCommand : IRequest
{
    public string OrderId { get; set; } = "";
    public OrderGoodsState State { get; set; } = OrderGoodsState.notStarted;
}

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.OrderGoods
            .FirstOrDefaultAsync(x => x.OrderId == request.OrderId , cancellationToken);

        if (entity != null) {
            entity.OrderStatus = request.State;
        }
        

        await _context.SaveChangesAsync(cancellationToken);

    }
}
