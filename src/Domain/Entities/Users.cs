namespace spacesApi.Domain.Entities;
public class Users
{
    public int Id { get; set; }
    public string Name { get; set; }=null!;
    public long PhoneNumber { get; set; }
    public int Money { get; set; }

    public ICollection<OrderGoods>? OrderGoods { get; set; }
}
