namespace spacesApi.Domain.Entities;
public class OrderGoods
{
    public int Id { get; set; }
    public int OrderId { get; set; } = 0;
    public int RoomId { get; set; }
    public int UserId { get; set; }
    public int Duration { get; set; } = 120;
    public OrderGoodsState OrderStatus { get; set; } = OrderGoodsState.notStarted;
    public Room Room { get; set; } = null!;
    public Users User { get; set; } = null!;
    public DateTime StartingTime { get; set; }
    public DateTime EndTime { get; set;}
    public DateTime CreatedDate { get; set;}

}
