using System.Xml.Linq;
using spacesApi.Application.Common.Interfaces;
using spacesApi.Application.Common.Mappings;
using spacesApi.Application.Common.Models;
using spacesApi.Application.Rooms.Queries.GetRoomListQuery;
using spacesApi.Application.Rooms.Queries.GetRoomWithPaginationQuery;
using spacesApi.Domain.Entities;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.Rooms.Queries.GetRoomWithPagination;

public record GetRoomWithPaginationQuery : IRequest<PaginatedList<RoomWithPaginationDto>>
{
    public string? RoomName { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetRoomWithPaginationQueryHandler : IRequestHandler<GetRoomWithPaginationQuery, PaginatedList<RoomWithPaginationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRoomWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<RoomWithPaginationDto>> Handle(GetRoomWithPaginationQuery request, CancellationToken cancellationToken)
    {
        DateTime dateTime = DateTime.Now;
        var a = await _context.Room
            .Where(x => String.IsNullOrEmpty(request.RoomName) ? x.Name != request.RoomName : x.Name == request.RoomName)
            .OrderBy(x => x.Id)
            .ProjectTo<RoomWithPaginationDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return a;
    }
}
