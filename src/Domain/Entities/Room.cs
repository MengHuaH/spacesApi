namespace spacesApi.Domain.Entities;
public class Room
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Money { get; set; }
    public string? ClientId { get; set; }
    public RoomState State { get; set; } = RoomState.closed;
    public RoomPersonnelSituation PersonnelSituation { get; set; } = RoomPersonnelSituation.not;//人员情况
    public RoomPowerSupply PowerSupply { get; set; } = RoomPowerSupply.closed;//电源

    public ICollection<OrderGoods> OrderGoods { get; set; } = [];
}
