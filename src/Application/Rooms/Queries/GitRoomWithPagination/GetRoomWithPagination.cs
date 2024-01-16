using spacesApi.Application.Common.Interfaces;
using spacesApi.Application.Common.Mappings;
using spacesApi.Application.Common.Models;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.Rooms.Queries.GetRoomWithPagination;

public record GetRoomWithPaginationQuery : IRequest<PaginatedList<Room>>
{
    public int Id { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetRoomWithPaginationQueryHandler : IRequestHandler<GetRoomWithPaginationQuery, PaginatedList<Room>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRoomWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<Room>> Handle(GetRoomWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Room
            .Where(x => x.Id == request.Id)
            .OrderBy(x => x.Id)
            .ProjectTo<Room>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
