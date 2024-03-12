using spacesApi.Domain.Entities;

namespace spacesApi.Application.OrderGoodss.Queries.GitOrderGoodsWithPagination;
public class OrderGoodsListDto
{
    public int Id { get; set; }
    public Room? Room { get; set; }
    public Users? User { get; set; }
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
            dto.Id = orderGoods.Id;
            dto.User = orderGoods.User;
            dto.Room = orderGoods.Room;
            dto.CreatedDate = orderGoods.CreatedDate;
            dto.EndTime = orderGoods.EndTime;
            dto.StartingTime = orderGoods.StartingTime;
        }
    }
}
