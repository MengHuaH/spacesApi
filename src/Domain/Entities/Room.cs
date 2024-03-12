namespace spacesApi.Domain.Entities;
public class Room
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Money { get; set; }
    public RoomState State { get; set; } = RoomState.closed;
    public RoomPersonnelSituation PersonnelSituation { get; set; } = RoomPersonnelSituation.not;
    public RoomPowerSupply PowerSupply { get; set; } = RoomPowerSupply.closed;

    public ICollection<OrderGoods>? OrderGoods { get; set; }
}
