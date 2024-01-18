using spacesApi.Application.Common.Interfaces;
using spacesApi.Application.Common.Mappings;
using spacesApi.Application.Common.Models;
using spacesApi.Application.OrderGoodss.Queries.GitOrderGoodsWithPagination;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.OrderGoodss.Queries.GetOrderGoodsWithPagination;

public record GetOrderGoodsWithPaginationQuery : IRequest<PaginatedList<OrderGoodsListDto>>
{
    public int? RoomId { get; init; }
    public long? PhoneNumber { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetOrderGoodsWithPaginationQueryHandler : IRequestHandler<GetOrderGoodsWithPaginationQuery, PaginatedList<OrderGoodsListDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetOrderGoodsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<OrderGoodsListDto>> Handle(GetOrderGoodsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.OrderGoods
               .Where(x => x.Room.Id == request.RoomId || x.User.PhoneNumber == request.PhoneNumber)
               .OrderBy(x => x.Id)
               .ProjectTo<OrderGoodsListDto>(_mapper.ConfigurationProvider)
               .PaginatedListAsync(request.PageNumber, request.PageSize); 
    }
}
