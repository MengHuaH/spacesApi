using spacesApi.Domain.Entities;

namespace spacesApi.Application.OrderGoodss.Queries.GitOrderGoodsWithPagination;
public class OrderGoodsListDto
{
    public int Id { get; set; }
    public string? RoomName { get; set; }
    public long PhoneNumber { get; set; }
    public DateTime StartingTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime CreatedDate { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<OrderGoods, OrderGoodsListDto>();
            OrderGoodsListDto dto = new OrderGoodsListDto();
            OrderGoods orderGoods = new OrderGoods();
            dto.PhoneNumber = orderGoods.User.PhoneNumber;
            dto.RoomName = orderGoods.Room.Name;
        }
    }
}
