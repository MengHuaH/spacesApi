using spacesApi.Application.Rooms.Queries.GetOrderGoodsWithPaginationQuery;
using spacesApi.Domain.Entities;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.Rooms.Queries.GetRoomWithPaginationQuery;

public class RoomWithPaginationDto
{
    public RoomWithPaginationDto()
    {
        OrderGoods = Array.Empty<OrderGoodsWithPaginationDto>();
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public int Money { get; set; }
    public string? ClientId { get; set; }
    public RoomState State { get; set; }
    public RoomPersonnelSituation PersonnelSituation { get; set; }//人员情况
    public RoomPowerSupply PowerSupply { get; set; }//电源

    public IReadOnlyCollection<OrderGoodsWithPaginationDto> OrderGoods { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Room, RoomWithPaginationDto>();
        }
    }
}
