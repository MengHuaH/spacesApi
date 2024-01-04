using spacesApi.Domain.Entities;

namespace spacesApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<Users> User { get; }
    DbSet<OrderGoods> OrderGoods { get; }
    DbSet<Room> Room { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
