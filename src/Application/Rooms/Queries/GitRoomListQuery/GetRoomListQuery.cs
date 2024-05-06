using System.Linq;
using spacesApi.Application.Common.Interfaces;
using spacesApi.Application.Common.Mappings;
using spacesApi.Application.Common.Models;
using spacesApi.Application.TodoLists.Queries.GetTodos;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.Rooms.Queries.GetRoomListQuery;

public record GetRoomListQuery : IRequest<List<RoomDto>>
{
    public string? RoomName { get; init; }

}


public class GetRoomListQueryHandler : IRequestHandler<GetRoomListQuery, List<RoomDto>>
{
    private readonly IApplicationDbContext _context;

    private readonly IMapper _mapper;

    public GetRoomListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;

        _mapper = mapper;
    }

    public async Task<List<RoomDto>> Handle(GetRoomListQuery request, CancellationToken cancellationToken)
    {
        var roomList = await _context.Room
            .Include(o => o.OrderGoods)
            .Where(x => x.Name == request.RoomName)
            .OrderBy(x => x.Id)
            .ProjectTo<RoomDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
        return roomList;
    }
}
