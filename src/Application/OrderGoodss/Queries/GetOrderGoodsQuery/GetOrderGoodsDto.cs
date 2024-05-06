using spacesApi.Domain.Entities;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.OrderGoodss.Queries.GetOrderGoodsQuery;

public class GetOrderGoodsDto
{
    public GetOrderGoodsDto()
    {
        Room = new RoomDto();
        User = new UserDto();
    }
    public int Id { get; init; }
    public string? OrderId { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public int Duration { get; set; }
    public OrderGoodsState OrderStatus { get; set; }
    public RoomDto Room { get; init; }
    public UserDto User { get; init; }
    public DateTime StartingTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedDate { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<OrderGoods, GetOrderGoodsDto>();
        }
    }
}
