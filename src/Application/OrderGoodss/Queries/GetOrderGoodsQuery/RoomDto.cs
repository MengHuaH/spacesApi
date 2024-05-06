using spacesApi.Domain.Entities;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.OrderGoodss.Queries.GetOrderGoodsQuery;

public class RoomDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Money { get; set; }
    public string? ClientId { get; set; }
    public RoomState State { get; set; }
    public RoomPersonnelSituation PersonnelSituation { get; set; }//人员情况
    public RoomPowerSupply PowerSupply { get; set; }//电源


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Room, RoomDto>();
        }
    }
}
