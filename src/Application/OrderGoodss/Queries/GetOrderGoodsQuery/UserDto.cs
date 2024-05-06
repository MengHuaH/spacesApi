using spacesApi.Domain.Entities;
using spacesApi.Domain.Enums;

namespace spacesApi.Application.OrderGoodss.Queries.GetOrderGoodsQuery;

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public long PhoneNumber { get; set; }
    public int Money { get; set; }


    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Users, UserDto>();
        }
    }
}
