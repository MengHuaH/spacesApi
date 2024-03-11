using spacesApi.Application.Common.Interfaces;
using spacesApi.Application.Common.Mappings;
using spacesApi.Application.Common.Models;
using spacesApi.Domain.Entities;

namespace spacesApi.Application.User.Queries.GetUsersWithPagination;

public record GetUsersWithPagination : IRequest<PaginatedList<Users>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetUsersWithPaginationHandler : IRequestHandler<GetUsersWithPagination, PaginatedList<Users>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUsersWithPaginationHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<Users>> Handle(GetUsersWithPagination request, CancellationToken cancellationToken)
    {
        return await _context.User
            .OrderBy(x => x.Id)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
