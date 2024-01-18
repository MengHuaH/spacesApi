using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.OrderGoodss.Commands.CreateOrderGoods;
public record CreateOrderGoodsCommand : IRequest<int>
{
    public Room Room { get; set; } = new Room();
    public Users User { get; set; } = new Users();
    public DateTime StartingTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class CreateOrderGoodsCommandHandler : IRequestHandler<CreateOrderGoodsCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderGoodsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateOrderGoodsCommand request, CancellationToken cancellationToken)
    {

        var entity = new OrderGoods();

        entity.Room = request.Room;

        entity.User = request.User;

        entity.StartingTime = request.StartingTime;

        entity.EndTime = request.EndTime;

        entity.CreatedDate = DateTime.Now;

        _context.OrderGoods.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
