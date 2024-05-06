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
        string mo = "0" + request.CreatedDate.Month.ToString();
        string d = ("0" + request.CreatedDate.Day.ToString());
        string h = ("0" + request.CreatedDate.Hour.ToString());
        string mi = ("0" + request.CreatedDate.Minute.ToString());
        string s = ("0" + request.CreatedDate.Second.ToString());

        string dateString = request.CreatedDate.Year.ToString()
            + mo.Substring(mo.Length - 2)
            + d.Substring(d.Length - 2)
            + h.Substring(h.Length - 2)
            + mi.Substring(mi.Length - 2)
            + s.Substring(s.Length - 2);
        var roomIdString = request.Room.Id.ToString();
        var phoneNuberString = request.User.PhoneNumber.ToString();

        var entity = new OrderGoods
        {
            OrderId = roomIdString + phoneNuberString + dateString,

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
            State = entity.OrderId
        };
        return orderGoodsDto;


    }
}
