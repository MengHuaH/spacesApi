using spacesApi.Domain.Entities;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.Rooms.Queries.GetRoomListQuery;

public class OrderGoodsDto
{
    public int Id { get; init; }
    public string? OrderId { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public int Duration { get; set; } = 120;
    public OrderGoodsState OrderStatus { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedDate { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<OrderGoods, OrderGoodsDto>();
        }
    }
}
