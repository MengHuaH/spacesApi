using spacesApi.Application.Common.Interfaces;
using spacesApi.Domain.Entities;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.OrderGoodss.Queries.GetOrderGoodsQuery;

public record GetOrderGoodsQuery : IRequest<List<GetOrderGoodsDto>>
{
    public int? RoomId { get; init; }
    public string? OrderId { get; init; }
    public OrderGoodsState? OrderStatus { get; init; } = OrderGoodsState.notStarted;
    public DateTime? Date { get; init; }
}

public class GetOrderGoodsQueryHandler : IRequestHandler<GetOrderGoodsQuery, List<GetOrderGoodsDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderGoodsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<GetOrderGoodsDto>> Handle(GetOrderGoodsQuery request, CancellationToken cancellationToken)
    {
        var a = await _context.OrderGoods
               .Include(r => r.Room)
               .Include(u => u.User)
               .Where(x => request.RoomId != null ? (x.RoomId == request.RoomId) : x.RoomId != 0)
               .Where(x => request.OrderId != null ? x.OrderId == request.OrderId : x.OrderId != null)
               .Where(x => request.Date == null ? x.StartingTime != DateTime.MinValue : x.EndTime >= request.Date)
               .OrderBy(x => x.StartingTime)
               .ProjectTo<GetOrderGoodsDto>(_mapper.ConfigurationProvider)
               .ToListAsync();
        if(request.OrderStatus != null)
        {
            a = a.Where(x => x.OrderStatus == request.OrderStatus).ToList();
        }
        return a;
    }
}
