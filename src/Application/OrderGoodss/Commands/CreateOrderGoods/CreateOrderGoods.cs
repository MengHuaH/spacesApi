using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.OrderGoodss.Commands.CreateOrderGoods;
public record CreateOrderGoodsCommand : IRequest<OrderGoodsDto>
{
    public Room Room { get; set; } = new Room();
    public Users User { get; set; } = new Users();
    public int Duration { get; set; } = 120;
    public DateTime StartingTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class CreateOrderGoodsCommandHandler : IRequestHandler<CreateOrderGoodsCommand, OrderGoodsDto>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderGoodsCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OrderGoodsDto> Handle(CreateOrderGoodsCommand request, CancellationToken cancellationToken)
    {
        var user = _context.User.Single(e => e.PhoneNumber == request.User.PhoneNumber);
        var roomMoney = _context.Room.Single(e => e.Id == request.Room.Id).Money;

        var entity = new OrderGoods
        {
            RoomId = request.Room.Id,

            UserId = user.Id,

            StartingTime = request.StartingTime,

            EndTime = request.EndTime,

            Duration = request.Duration,

            OrderStatus = Domain.Enums.OrderGoodsState.notStarted,

            CreatedDate = DateTime.Now
        };

        user.Money -= (request.Duration / 60 * roomMoney);

        _context.OrderGoods.Add(entity);
        _context.User.Update(user);

        await _context.SaveChangesAsync(cancellationToken);

        OrderGoodsDto orderGoodsDto = new()
        {
            Id = entity.Id,
            State = "创建成功"
        };
        return orderGoodsDto;


    }
}
